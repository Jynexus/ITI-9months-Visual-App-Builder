using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace VisualApplicationBuilder.ResourceClasses
{
    public class BlockBase : UserControl
    {
        public bool IsHighlighted { get; set; }

        // build the string
        public virtual string ToExecString()
        {
            return "{}";
        }

        // report current status
        public virtual bool currentStatus()
        {
            return false;
        }

        // save/load the block into/from XML
        public virtual void ToXml(XmlWriter x)
        {
            return;
        }
        public virtual void FromXml(XmlNode node)
        {
            return;
        }
        //
        // Event handlers
        //
        // Remove block button
        protected void buttonRemoveBlock_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(.15)));

            fadeOutAnimation.Completed += delegate(object sender1, EventArgs e1)
            {
                StackPanel parentContainer = (StackPanel)this.Parent;

                (this.Parent as Panel).Children.Remove(this);
                
                parentContainer.LayoutUpdated += delegate(object sender2, EventArgs e2)
                {
                    if (parentContainer.Children.Count > 0 && parentContainer != Utilities.mainStackPanel)
                        resize((BlockBase)parentContainer.Children[parentContainer.Children.Count - 1], parentContainer, true);
                };
                    
            };

            this.BeginAnimation(OpacityProperty, fadeOutAnimation);
        }

        // MouseEnver on read buttons
        protected void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = (SolidColorBrush)Application.Current.Resources["BrightRedBrush"];
        }
        protected void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = (SolidColorBrush)Application.Current.Resources["ActiveButtonBackgroundBrush"];
        }
        protected void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = (SolidColorBrush)Application.Current.Resources["BackgroundBrush"];
        }

        // Drag-Drop
        protected void Block_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() != typeof(StackPanel))
            {
                Utilities.isPressed = true;
                Utilities.startPoint = e.GetPosition(this);
            }
        }
        protected void Block_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Utilities.isPressed = false;
            Utilities.isDragging = false;
            Mouse.Capture(null);
        }
        protected void Block_MouseMove(object sender, MouseEventArgs e)
        {
            Vector movement = e.GetPosition(this) - Utilities.startPoint;

            if (Utilities.isPressed)
            {
                if (Utilities.isDragging == false &&
                    (Math.Abs(movement.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(movement.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    Utilities.isDragging = true;
                    Utilities.realDragSource = GetParentBlock(e.OriginalSource as FrameworkElement);
                    Mouse.Capture(Utilities.realDragSource);

                    Utilities.blockType = e.Source.GetType();
                    DataObject dataBlock = new DataObject(Utilities.blockType, Utilities.realDragSource);
                    
                    DragDrop.DoDragDrop(Utilities.realDragSource, dataBlock, DragDropEffects.Move);
                }
            }
        }
        protected void stackPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Source.GetType() == typeof(StackPanel))
                e.Effects = DragDropEffects.Move;
        }
        protected void stackPanel_Drop(object sender, DragEventArgs e)
        {
            try
            {
                // rearranging blocks
                if (e.Source.GetType() == typeof(Grid))
                {
                    BlockBase dropSource = this;

                    StackPanel MainStackPanel = this.Parent as StackPanel;
                    int indexDrag = MainStackPanel.Children.IndexOf(Utilities.realDragSource);
                    int indexDrop = MainStackPanel.Children.IndexOf(dropSource);

                    if (indexDrag > -1)
                        MainStackPanel.Children.RemoveAt(indexDrag);

                    if (indexDrop != -1)
                        MainStackPanel.Children.Insert(indexDrop, Utilities.realDragSource);
                }

                // dropping within a block
                if (e.Source.GetType() == typeof(StackPanel))
                {
                    StackPanel dropSource = e.Source as StackPanel;

                    // dragged block
                    BlockBase draggedData = (BlockBase)e.Data.GetData(Utilities.blockType);
                    draggedData.Margin = new Thickness(10, 10, 0, 0);


                    // if the Block is already instantiated, remove it from its old parent's tree
                    Panel parentPanel = (Panel)draggedData.Parent;
                    if (parentPanel != null)
                        parentPanel.Children.Remove(draggedData);

                    // insert the dragged block into the tree of its new parent
                    int index = dropSource.Children.Count;
                    dropSource.Children.Insert(index, draggedData);
                    BlockBase lastChild = dropSource.Children[index] as BlockBase;

                    resize(lastChild, dropSource, false);
                }
            }

            catch (Exception e1)
            {
                string dragSource = Utilities.realDragSource.GetType().ToString();
                string dropSource = e.Source.GetType().ToString();
            }

            finally
            {
                Utilities.isPressed = false;
                Utilities.isDragging = false;

                Mouse.Capture(null);
            }
        }
    
        // Resizing Parent blocks event 
        protected void blockControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            BlockBase child = (BlockBase)sender;

            if (child.Parent.GetType() == typeof(StackPanel) && ((StackPanel)child.Parent).Parent.GetType() != typeof(ScrollViewer))
                resize(child, (StackPanel)child.Parent, true);
        }

        // Highlighting
        protected void buttonHighlight_Click(object sender, RoutedEventArgs e)
        {
            IsHighlighted = true;
            RebuildExecString();
            IsHighlighted = false;
        }
        //
        // Helper methods
        //
        public void resize(BlockBase lastChild, StackPanel dropSource, bool isSizeChanged)
        {
            this.Refresh(); // really necessary call!!!!

            // calculate the new height of the parent block
            double height = lastChild.ActualHeight + lastChild.TranslatePoint(new Point(0, 0), dropSource).Y;
            this.Refresh(); // necessary call, trust me!

            // getting the parent grid of the drop area (Grid > Border > StackPanel)
            FrameworkElement dropContainer = (FrameworkElement)((FrameworkElement)((FrameworkElement)lastChild.Parent).Parent).Parent;
            double oldHeight = dropContainer.ActualHeight;
            //DoubleAnimation resizeStackPanelAnimation = new DoubleAnimation(oldHeight, height + 50, new Duration(TimeSpan.FromSeconds(.1)));
            //dropContainer.BeginAnimation(HeightProperty, resizeStackPanelAnimation);

            this.Refresh(); // still necessary.

            // resize the block itself
            BlockBase theParentBlock = new BlockBase();

            //to check whether the resize is called from drop event or sizechanged event
            if (isSizeChanged)
                theParentBlock = GetParentBlock(dropSource);
            else
                theParentBlock = this;

            DoubleAnimation resizeBlockAnimation = new DoubleAnimation(theParentBlock.Height, theParentBlock.Height + height + 50 - oldHeight, new Duration(TimeSpan.FromSeconds(.1)));
            theParentBlock.BeginAnimation(HeightProperty, resizeBlockAnimation);
            this.Refresh(); // you guessed it! necessary, it is.

            // width resizing
            if (Utilities.maxBlockWidth != 0)
                this.Width = Utilities.maxBlockWidth;

            else
            {
                double width = 0;
                foreach (BlockBase block in dropSource.Children)
                {
                    if (block.ActualWidth > width)
                        width = block.ActualWidth;
                }
                DoubleAnimation resizeWidthAnimation = new DoubleAnimation(theParentBlock.Width, width + 45, new Duration(TimeSpan.FromSeconds(.1)));
                theParentBlock.BeginAnimation(WidthProperty, resizeWidthAnimation);
            }

            this.Refresh(); // ohhhhhhh, yeah!!
        }
        public BlockBase GetParentBlock(FrameworkElement child)
        {
            Utilities.grandParent = child.Parent;
            while (Utilities.grandParent != null &&  Utilities.grandParent.GetType().BaseType != typeof(BlockBase))
                Utilities.grandParent = VisualTreeHelper.GetParent((DependencyObject)Utilities.grandParent);

            return Utilities.grandParent as BlockBase;
        }
        private bool CheckIsHighlighted ()
        {
            BlockBase block = this;
            do
            {
                if (block.IsHighlighted == true)
                    return true;

                block = GetParentBlock(block);
            } while (block != null);

            return false;
        }
        public void AppendToCodeBlock(string s)
        {
            if (CheckIsHighlighted())
                Utilities.codeTextBlock.Inlines.Add(new Span(new Run(s)) { Background = (Brush)Application.Current.Resources["BlueBrush"] });

            else
                Utilities.codeTextBlock.Inlines.Add(new Run(s));
        }

        // re-generate the code - called on: Drop, Click of buttonHighlight, Click of buttonExecute
        public static void RebuildExecString()
        {
            // clear old build
            Utilities.codeTextBlock.Inlines.Clear();
            // Utilities.codeTextBlock.Text = "";
            Utilities.execString = "";
            
            foreach (BlockBase block in Utilities.mainStackPanel.Children)
                Utilities.execString += block.ToExecString();
        }
    }
    //
    // application variables
    //
    public static class Utilities
    {
        // drag/drop variables
        public static bool isPressed;
        public static bool isDragging;
        public static Point startPoint;
        public static UIElement realDragSource;
        public static UIElement dummyDragSource = new UIElement();
        public static Type blockType;
        
        public static StackPanel mainStackPanel; // holds the top-level application StackPanel

        public static bool helpActive = false;

        public static string indent = ""; // holds the current indent level

        public static object grandParent;
        public static double maxBlockWidth = 0;

        public static TextBlock codeTextBlock; // holds the text block in the application window to reference within the blocks code
        public static string execString;

        #region tool tips
        //ClassBlock
        public static string classString = "Classes is essentially templates from which you can create objects.\n Each object contains data and has methods to manipulate and access that data.";
        public static string classModifier = "Modifier is : how other member can access this class\nPublic all other member can access it .\nProtected just closed members can access it .\nPrivate no other members can access it .";
        public static string className = "Name has some restrictions :\n- You can't start your name with numbers .\n- you can't start name with symbols (just underscoor ( _ )) ." + "\n";
        public static string classBody = "You can put any control in the class body exclude :\n- namespace block\n- using block";

        //ForBLock
        public static string forString = "C# for loops provide a mechanism for iterating through a loop \n whereby you test whether a particular condition holds true before you perform another iteration.\nfor (initializer; condition; iterator)\nstatement(s)";
        public static string forInitialization = "you should initialize the for loop with initialized vriable with a data type :\nEX : int i=0 or double x=2.5";
        public static string forCondition = "you should put the condition that stop the loop :\nEX : i > 5 or i < 10.5\nyou don't have to write the data type again in the condition";
        public static string forincrement = "you shuold descripe how your loop to increment (increment by 1 or any number) or how it decremented\nEX : i++ or i-- and i+2(by 2) or i-2";
        public static string forBody = "You can put any control in the class body exclude :\n- namespace block\n- using block\n- class block\n- Method block\n- struct block";

        //FromFileBlock
        public static string fromfileString = "To get a value from file usually string";
        public static string fromFileName = "Just type your file name";
        public static string fromVariableContent = "Identify your variable that you want to save it in the file";

        //ToFile
        public static string tofileString = "To set a value to file usually string";
        public static string toFileName = "just choose your file";
        public static string toContent = "choose the variable which you want to put the content" + "Note : " + "Be carefule to choose variable with suitable type";

        //IfBlock
        public static string ifString = "If statement is a conditional statements \n allow you to branch your code depending on whether certain conditions are met or the value of an expression.";
        public static string ifCondition = "It's the condition you want to chek it :\nEX : i != 5\nNote : " + "you can't use a single smile emoticon => used for assign value) use (==)\nEx : i == 5 or i <= 8 or i != 5 ( != is the opposite of == )";
        public static string thenBody = "Then you cann write the code statements you want to execute if the condition is true";
        public static string elseBody = "Then you cann write the code statements you want to execute if the condition is false";

        //InputBlock
        public static string inputString = "To get a value printed in the screen by the user";
        public static string inputDataType = "Type here is for the primitive type (can hold just one value) :\nEx : int can hold just one number (like : 1253)\nPrimitive Type examples : \nint (holds numbers without precision) .\n double (holds numbers with 1 or 2 precision) .\nfloat (holds numbers with 1 precision but with smaller range than double) .\nChar (holds just one char) .";
        public static string inputOutputVariable = "The variable that you want to be the reciever of the input :\nEX : you want to write in the screen (pleas enter your name) \nYou should write ('please enter your name') with the bracets";

        //MethodBlock
        public static string methodString = "A method is a code block that contains a series of statements.\n A program causes the statements to be executed by calling the method \n and specifying any required method arguments";
        public static string methodModifier = "Modifier is : how other member can access this class\nPublic all other member can access it .\nProtected just closed members can access it .\nPrivate no other members can access it .";
        public static string methodReturnType = "Methods can return a value to the caller. \nIf the return type, the type listed before the method name is not void\n the method can return the value by using the return keyword. \n A statement with the return keyword followed by a value that matches the return type \n will return that value to the method caller\nEX : function string MyFunction(int i)\n string s='i ='+i;\nreturn s;";
        public static string methodName = " Name has some restrictions :\n- You can't start your name with numbers .\n- you can't start name with symbols (just underscoor ( _ )) ." + "\n";
        public static string methodparameterDataType = "Type here is for the primitive type (can hold just one value) :\nEx : int can hold just one number (like : 1253)\nPrimitive Type examples : \nint (holds numbers without precision) .\n double (holds numbers with 1 or 2 precision) .\nfloat (holds numbers with 1 precision but with smaller range than double) .\nChar (holds just one char) .";
        public static string methodparameterName = "Name has some restrictions :\n- You can't start your name with numbers .\n- you can't start name with symbols (just underscoor ( _ )) ." + "\n";
        public static string methodBody = "you can here put any block you want in the namespace block\nExclude : using , namespace , class blocks";

        //NamespaceBlock
        public static string namespaceString = "a namespace is a logical that\nprovide a way to organize related classes and other types";
        public static string namespaeName = "Name has some restrictions :\n- You can't start your name with numbers .\n- you can't start name with symbols (just underscoor ( _ )) ." + "\n";
        public static string namespaceBody = "you can here put any block you want in the namespace block\nExclude : using block";

        //OutputBlock
        public static string outputString = "To print string in the screen to the user";
        public static string outputText = "The text you want to be printed in the screen \nEX : please enter your age";

        //StatementBlock
        public static string statementText = "Write any statement you want to be executed\nEX : you can use anystring generated from any block\nand write it here";

        //StructBlock
        public static string structString = "A struct type is a value type that is typically used to encapsulate small groups of related variables,\n such as the coordinates of a rectangle or the characteristics of an item in an inventory.";
        public static string structModifier = "Modifier is : how other member can access this struct\nPublic all other member can access it .\nProtected just closed members can access it .\nPrivate no other members can access it .";
        public static string structName = "Name has some restrictions :\n- You can't start your name with numbers .\n- you can't start name with symbols (just underscoor ( _ )) ." + "\n";

        //SwitchBlock
        public static string switchString = "The switch / case statement is good for selecting one branch of execution from a set of mutually exclusive ones.\n It takes the form of a switch argument followed by a series of case clauses.";
        public static string switchVariable = "The value to check its value in the conditions";
        public static string switchcase = "Is a case to implement it's code if it's condition is true";
        public static string switchDefaultCase = "Is the case that will implemented by default if no case reached throw looping";

        //UsingBlock
        public static string usingString = "Using block it's a directive to let the application knows which built-in code to include";
        public static string usinngMains = "To determine witch category of namespaces";
        public static string usinngnamespace = "Determine whitch namespace you want to include";


        public static string variableString = "storage location paired with an associated symbolic name,\n which contains some known or unknown quantity or information referred to as a value";
        public static string variableComplex = "Complex type is a type than can hold one more than value :\nEX : Array can hold multiple values";
        public static string variableType = "Type here is for the primitive type (can hold just one value) :\nEx : int can hold just one number (like : 1253)";
        public static string variableIdentifier = "Name has some restrictions :\n- You can't start your name with numbers .\n- you can't start name with symbols (just underscoor ( _ )) ." + "\n";

        #endregion

        // force the update of the layout
        private static Action EmptyDelegate = delegate() { };
        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}