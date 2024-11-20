using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Xml;
using VisualApplicationBuilder.Block;
using VisualApplicationBuilder.ResourceClasses;

namespace VisualApplicationBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPressed;
        bool isDragging;
        Point startPoint;
        UIElement realDragSource;
        UIElement dummyDragSource = new UIElement();

        public MainWindow()
        {
            InitializeComponent();

            this.WindowStyle = System.Windows.WindowStyle.None;
            this.WindowState = System.Windows.WindowState.Maximized;

            borderCodePanel.Visibility = System.Windows.Visibility.Collapsed;
            borderCodePanel.IsEnabled = false;
            buttonCodePanel.Content = "<";

            Utilities.mainStackPanel = stackPanelDropZone;
            Utilities.codeTextBlock = textBlockCode;

            LoadProject(@".\..\..\Template\defaultTemplate.vabp");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(Button))
            {
                isPressed = true;
                startPoint = e.GetPosition(this);
            }
        }
        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Vector movement = e.GetPosition(this) - startPoint;

            if (isPressed && e.Source.GetType() == typeof(Button))
            {
                if (isDragging == false &&
                    (Math.Abs(movement.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(movement.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    isDragging = true;
                    realDragSource = e.Source as UIElement;
                    realDragSource.CaptureMouse();

                    string buttonName = ((Button)e.Source).Name;
                    BlockBase newBlock = new BlockBase();
                    switch (buttonName)
                    {
                        case "buttonUsing":
                            newBlock = new UsingBlock();
                            Utilities.blockType = typeof(UsingBlock);
                            break;

                        case "buttonNamespace":
                            newBlock = new NamespaceBlock();
                            Utilities.blockType = typeof(NamespaceBlock);
                            break;

                        case "buttonClass":
                            newBlock = new ClassBlock();
                            Utilities.blockType = typeof(ClassBlock);
                            break;

                        case "buttonStruct":
                            newBlock = new StructBlock();
                            Utilities.blockType = typeof(StructBlock);
                            break;

                        case "buttonMethod":
                            newBlock = new MethodBlock();
                            Utilities.blockType = typeof(MethodBlock);
                            break;

                        case "buttonVariable":
                            newBlock = new VariableBlock();
                            Utilities.blockType = typeof(VariableBlock);
                            break;

                        case "buttonStatement":
                            newBlock = new StatementBlock();
                            Utilities.blockType = typeof(StatementBlock);
                            break;

                        case "buttonCondition":
                            newBlock = new ifThenElseBlock();
                            Utilities.blockType = typeof(ifThenElseBlock);
                            break;

                        case "buttonLoop":
                            newBlock = new ForBlock();
                            Utilities.blockType = typeof(ForBlock);
                            break;

                        case "buttonSwitch":
                            newBlock = new SwitchBlock();
                            Utilities.blockType = typeof(SwitchBlock);
                            break;

                        case "buttonInput":
                            newBlock = new InputBlock();
                            Utilities.blockType = typeof(InputBlock);
                            break;

                        case "buttonOutput":
                            newBlock = new OutputBlock();
                            Utilities.blockType = typeof(OutputBlock);
                            break;

                        case "buttonFromFile":
                            newBlock = new FromFileBlock();
                            Utilities.blockType = typeof(FromFileBlock);
                            break;

                        case "buttonToFile":
                            newBlock = new ToFileBlock();
                            Utilities.blockType = typeof(ToFileBlock);
                            break;
                    }

                    newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    newBlock.Margin = new Thickness(10, 10, 0, 0);

                    DataObject data = new DataObject(Utilities.blockType, newBlock);

                    DragDrop.DoDragDrop(realDragSource, data, DragDropEffects.Move);
                }
            }
        }
        private void stackPanelDropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(UsingBlock)) && e.Source.GetType() == typeof(StackPanel))
                e.Effects = DragDropEffects.Move;
        }
        private void stackPanelDropZone_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(Utilities.blockType) && e.Source.GetType() == typeof(StackPanel))
                {
                    // only valid blocks will be allowed to drop
                    if (Utilities.blockType == typeof(UsingBlock) || Utilities.blockType == typeof(NamespaceBlock))
                    {
                        BlockBase draggedData = (BlockBase)e.Data.GetData(Utilities.blockType);

                        // if the Block is already instantiated, remove it from its old parent's tree
                        Panel parentPanel = (Panel)draggedData.Parent;

                        if (parentPanel != null)
                            parentPanel.Children.Remove(draggedData);

                        draggedData.Margin = new Thickness(250, 10, 0, 0);
                        stackPanelDropZone.Children.Add(draggedData);
                    }
                    else
                    {
                        Window window = new BlocksAll.CustomMessageBox("Illegal drop", "Only blocks of type \"UsingBlock\" or \"NamespaceBlock\" are allowed to be dropped on this level.");
                        window.ShowDialog();
                    }
                }
            }

            catch (Exception e1)
            {
                Window window = new BlocksAll.CustomMessageBox("Illegal drop", "This type of block can not be dropped here!!");
                window.ShowDialog();
            }

            finally
            {
                isPressed = false;
                isDragging = false;

                Mouse.Capture(null);
            }
        }

        private void gridMain_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isPressed = false;
            isDragging = false;
            Mouse.Capture(null);
        }

        private void stackPanelDropZone_DragOver(object sender, DragEventArgs e)
        {
            if (e.GetPosition(this).Y > 700)
                scrollViewerDropZone.LineDown();

            if (e.GetPosition(this).Y < 150)
                scrollViewerDropZone.LineUp();
        }

        private void buttonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void buttonMinimizeApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            if (!Utilities.helpActive)
            {
                Utilities.helpActive = true;
                Mouse.OverrideCursor = Cursors.Help;
                buttonHelp.Background = (SolidColorBrush)Application.Current.Resources["BorderBrush2"];
            }
            else
            {
                Utilities.helpActive = false;
                Mouse.OverrideCursor = Cursors.Arrow;
                buttonHelp.Background = (SolidColorBrush)Application.Current.Resources["BackgroundBrush"];
            }
        }

        private void buttonSaveCode_Click(object sender, RoutedEventArgs e)
        {
            BlockBase.RebuildExecString();

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Save Code";
            saveDialog.AddExtension = true;
            saveDialog.Filter = "CSharp file (*.cs)|*.cs";

            if ((bool)saveDialog.ShowDialog())
            {
                string fileName = saveDialog.FileName;

                File.WriteAllText(fileName, Utilities.execString);
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Save project";
            saveDialog.AddExtension = true;
            saveDialog.Filter = "Visual Application Builder project files (*.vabp)|*.vabp";

            if ((bool)saveDialog.ShowDialog())
            {
                string fileName = saveDialog.FileName;

                XmlWriter x = XmlWriter.Create(fileName);
                x.WriteStartDocument();
                x.WriteStartElement("Blocks");

                foreach (BlockBase block in Utilities.mainStackPanel.Children)
                    block.ToXml(x);

                x.WriteEndElement();
                x.WriteEndDocument();
                x.Close();

                labelProjectName.Content = saveDialog.SafeFileName;
            }
        }
        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Title = "Open project";
            openDialog.AddExtension = true;
            openDialog.Filter = "Visual Application Builder project files (*.vabp)|*.vabp";

            if ((bool)openDialog.ShowDialog())
            {
                labelProjectName.Content = openDialog.SafeFileName;
                stackPanelDropZone.Children.Clear();

                LoadProject(openDialog.FileName);
            }
        }
        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            stackPanelDropZone.Children.Clear();
            labelProjectName.Content = "New Project.vabp";

            LoadProject(@".\..\..\Template\defaultTemplate.vabp");
        }

        private void buttonGenerateCode_Click(object sender, RoutedEventArgs e)
        {
            BlockBase.RebuildExecString();
        }
        private void buttonExecute_Click(object sender, RoutedEventArgs e)
        {
            BlockBase.RebuildExecString();

            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            string Output = "Out.exe";
            Button ButtonObject = (Button)sender;

            string error = "";
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            //Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;


            #region DLLs
            // System
            parameters.ReferencedAssemblies.Add("System.EnterpriseServices.dll");
            parameters.ReferencedAssemblies.Add("System.Globalization.dll");
            parameters.ReferencedAssemblies.Add("System.Linq.dll");
            parameters.ReferencedAssemblies.Add("System.Linq.Expressions.dll");
            parameters.ReferencedAssemblies.Add("System.Reflection.dll");
            parameters.ReferencedAssemblies.Add("System.Reflection.Emit.dll");
            parameters.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
            parameters.ReferencedAssemblies.Add("System.Runtime.Serialization.Json.dll");
            parameters.ReferencedAssemblies.Add("System.Security.dll");
            parameters.ReferencedAssemblies.Add("System.Security.Principal.dll");
            parameters.ReferencedAssemblies.Add("System.ServiceProcess.dll");
            parameters.ReferencedAssemblies.Add("System.Text.RegularExpressions.dll");
            parameters.ReferencedAssemblies.Add("System.Threading.dll");
            parameters.ReferencedAssemblies.Add("System.Transactions.dll");

            //Microsoft DLLs
            parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
            #endregion


            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, Utilities.execString);

            if (results.Errors.Count > 0)
            {

                foreach (CompilerError CompErr in results.Errors)
                {
                    error = error +
                                "Line number " + CompErr.Line +
                                ", Error Number: " + CompErr.ErrorNumber +
                                ", '" + CompErr.ErrorText + ";" +
                                Environment.NewLine + Environment.NewLine;
                }
                Window window = new BlocksAll.CustomMessageBox("Error", error);
                window.ShowDialog();
            }
            else
            {
                error = "Success!";
                Window window = new BlocksAll.CustomMessageBox("Success", error);
                window.ShowDialog();

                //If we clicked run then launch our EXE
                Process.Start(Output);
            }
        }

        private void buttonCodePanel_Click(object sender, RoutedEventArgs e)
        {
            if (borderCodePanel.Visibility == System.Windows.Visibility.Visible)
            {
                borderCodePanel.Visibility = System.Windows.Visibility.Collapsed;
                borderCodePanel.IsEnabled = false;
                buttonCodePanel.Content = "<";

                foreach(BlockBase block in stackPanelDropZone.Children)
                {
                    ThicknessAnimation marginAnimation = new ThicknessAnimation(new Thickness(250, 10, 0, 0), new Duration(TimeSpan.FromSeconds(.1)));
                    block.BeginAnimation(MarginProperty, marginAnimation);
                }
            }
            else
            {
                borderCodePanel.Visibility = System.Windows.Visibility.Visible;
                borderCodePanel.IsEnabled = true;
                buttonCodePanel.Content = ">";

                foreach (BlockBase block in stackPanelDropZone.Children)
                {
                    ThicknessAnimation marginAnimation = new ThicknessAnimation(new Thickness(10, 10, 0, 0), new Duration(TimeSpan.FromSeconds(.1)));
                    block.BeginAnimation(MarginProperty, marginAnimation);
                }
            }
        }

        // Theme :)
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxTheme.SelectedIndex == 0) // darkTheme
            {
                #region Brushes
                Application.Current.Resources["BackgroundBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#222"));
                Application.Current.Resources["BackgroundBrush2"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF2E2E2E"));
                Application.Current.Resources["BackgroundBrush3"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#33333333"));
                Application.Current.Resources["BorderBrush"] = Brushes.LightSteelBlue;
                Application.Current.Resources["BorderBrush2"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#555"));

                Application.Current.Resources["BlueBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007ACC"));
                Application.Current.Resources["OrangeBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD64D1A"));
                Application.Current.Resources["RedBrush"] = Brushes.Firebrick;

                Application.Current.Resources["DisabledBackgroundBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#EEE"));
                #endregion

                #region icons
                buttonCloseApp.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\close.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20
                };
                buttonMinimizeApp.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\minimize.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20
                };
                buttonHelp.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\help.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20
                };
                buttonNew.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\new.png", UriKind.Relative))
                };
                buttonOpen.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\open.png", UriKind.Relative))
                };
                buttonSave.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\save.png", UriKind.Relative))
                };
                buttonSaveCode.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\savecs.png", UriKind.Relative))
                };
                buttonExecute.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\execute.png", UriKind.Relative))
                };
                #endregion
            }
            else
            {
                #region Brushes
                Application.Current.Resources["BackgroundBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DDD"));
                Application.Current.Resources["BackgroundBrush2"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AAA"));
                Application.Current.Resources["BackgroundBrush3"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CCC"));
                Application.Current.Resources["BorderBrush2"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#888"));
                
                Application.Current.Resources["BlueBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007ACC"));
                Application.Current.Resources["OrangeBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD64D1A"));
                Application.Current.Resources["RedBrush"] = Brushes.Firebrick;

                Application.Current.Resources["DisabledBackgroundBrush"] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#111"));
                #endregion

                #region icons
                buttonCloseApp.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\closeInverted.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20
                };
                buttonMinimizeApp.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\minimizeInverted.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20
                };
                buttonHelp.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\helpInverted.png", UriKind.Relative)),
                    Width = 20,
                    Height = 20
                };
                buttonNew.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\newInverted.png", UriKind.Relative))
                };
                buttonOpen.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\openInverted.png", UriKind.Relative))
                };
                buttonSave.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\saveInverted.png", UriKind.Relative))
                };
                buttonSaveCode.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\savecsInverted.png", UriKind.Relative))
                };
                buttonExecute.Content = new Image()
                {
                    Source = new BitmapImage(new Uri(@".\..\..\img\startInverted.png", UriKind.Relative))
                };
                #endregion
            }

            // save the current project
            string fileName = @".\..\..\Template\temp.vabp";

            XmlWriter x = XmlWriter.Create(fileName);
            x.WriteStartDocument();
            x.WriteStartElement("Blocks");

            foreach (BlockBase block in stackPanelDropZone.Children)
                block.ToXml(x);

            x.WriteEndElement();
            x.WriteEndDocument();
            x.Close();

            // reload the current project
            stackPanelDropZone.Children.Clear();
            LoadProject(fileName);

            this.Refresh();
        }
        //
        // Helper method(s)
        //
        private void LoadProject(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            BlockBase newBlock = new BlockBase();
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                switch (node.Name)
                {
                    case "Using":
                        newBlock = new UsingBlock();
                        newBlock.FromXml(node); // initialize the block with save values

                        stackPanelDropZone.Children.Add(newBlock);
                        break;

                    case "Namespace":
                        newBlock = new NamespaceBlock();
                        newBlock.FromXml(node); // initialize the block with save values

                        stackPanelDropZone.Children.Add(newBlock);
                        break;

                    // create a messagebox showing a file error
                    default:
                        Window window = new BlocksAll.CustomMessageBox("File load error", "file is currupt!");
                        window.ShowDialog();

                        stackPanelDropZone.Children.Clear();
                        return; // stop reading the file.
                }

                newBlock.Margin = new Thickness(250, 10, 0, 0);
                newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            } // foreach
        }

    }
}