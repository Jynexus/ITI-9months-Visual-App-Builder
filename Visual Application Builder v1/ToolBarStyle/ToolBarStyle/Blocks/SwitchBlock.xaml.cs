using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using VisualApplicationBuilder.ResourceClasses;
using System.Windows.Media.Animation;
using System.Xml;
using System.Web;


namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SwitchBlock : BlockBase
    {
        public Boolean varStatus = false;
        public Boolean caseStatus = false;
        public SwitchBlock()
        {
            InitializeComponent();

            // wiring events to their handlers
            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            // this.SizeChanged += blockControl_SizeChanged;

            stackPanelDefault.DragEnter += stackPanel_DragEnter;
            stackPanelDefault.Drop += stackPanel_Drop;

            buttonHighlight.Click += buttonHighlight_Click;
        }

        private void buttonAddCase_Click(object sender, RoutedEventArgs e)
        {   
            Grid gridCase = new Grid();
            gridCase.Margin = new Thickness(10, 10, 10, 0);
            gridCase.Height = 225;

            Grid caseStatementGrid = new Grid();
            caseStatementGrid.Height = 25;
            caseStatementGrid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            
            #region case header
            // case block header - label
            Border caseStatementBorder1 = new Border();
            caseStatementBorder1.Width = 90;
            caseStatementBorder1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            caseStatementBorder1.BorderThickness = new Thickness(1);
            caseStatementBorder1.BorderBrush = (SolidColorBrush)Application.Current.Resources["BlueBrush"];

            TextBox caseStatementLabel = new TextBox();
            caseStatementLabel.Text = "case";
            caseStatementLabel.IsReadOnly = true;
            caseStatementLabel.BorderBrush = null;
            caseStatementLabel.Background = null;
            caseStatementLabel.Foreground = (SolidColorBrush)Application.Current.Resources["BorderBrush"];
            caseStatementBorder1.Child = caseStatementLabel;


            // case block header - textbox
            Border caseStatementBorder2 = new Border();
            caseStatementBorder2.Margin = new Thickness(90, 0, 0, 0);
            caseStatementBorder2.BorderThickness = new Thickness(0, 1, 1, 1);
            caseStatementBorder2.BorderBrush = (SolidColorBrush)Application.Current.Resources["BlueBrush"];
            caseStatementBorder2.Background = (SolidColorBrush)Application.Current.Resources["BorderBrush"];

            TextBox caseStatementTextBox = new TextBox();
            caseStatementTextBox.Margin = new Thickness(0, 0, 40, 0);
            caseStatementTextBox.BorderBrush = null;
            caseStatementTextBox.Background = null;
            caseStatementBorder2.Child = caseStatementTextBox;

            Button buttonRemoveCase = new Button();
            buttonRemoveCase.Click += buttonRemoveCase_Click;
            buttonRemoveCase.OpacityMask = (DrawingBrush)Application.Current.Resources["RemoveParameterButtonBrush"];
            buttonRemoveCase.Background = (SolidColorBrush)Application.Current.Resources["RedBrush"];
            buttonRemoveCase.Width = 23;
            buttonRemoveCase.Height = 23;
            buttonRemoveCase.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            buttonRemoveCase.Margin = new Thickness(0, 0, 10, 0);
            buttonRemoveCase.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            buttonRemoveCase.Style = (Style)Application.Current.Resources["AlphaButtonStyle"];
            
            caseStatementGrid.Children.Add(caseStatementBorder1);
            caseStatementGrid.Children.Add(caseStatementBorder2);
            caseStatementGrid.Children.Add(buttonRemoveCase);

            #endregion

            #region case stack panel
            
            // border
            Border caseBodyBorder = new Border();
            caseBodyBorder.BorderThickness = new Thickness(1);
            caseBodyBorder.BorderBrush = (SolidColorBrush)Application.Current.Resources["BlueBrush"];
            caseBodyBorder.Margin = new Thickness(0, 24, 0, 0);

            StackPanel caseBodyStackPanel = new StackPanel();
            caseBodyStackPanel.Background = (SolidColorBrush)Application.Current.Resources["BackgroundBrush"];
            caseBodyStackPanel.DragEnter += stackPanel_DragEnter;
            caseBodyStackPanel.Drop += stackPanel_Drop;

            caseBodyBorder.Child = caseBodyStackPanel;

            gridCase.Children.Add(caseStatementGrid);
            gridCase.Children.Add(caseBodyBorder);

            #endregion
            // finally, add the entire case grid to the control. sheww! That was a long journey!
            stackPanelOuter.Children.Insert(stackPanelOuter.Children.Count - 1, gridCase);

            DoubleAnimation resizeBlockAnimation = new DoubleAnimation(this.Height, this.Height + 235, new Duration(TimeSpan.FromSeconds(.1)));
            this.BeginAnimation(HeightProperty, resizeBlockAnimation);
        }

        private void buttonRemoveCase_Click(object sender, RoutedEventArgs e)
        {
            Grid gridCase = ((e.Source as Button).Parent as Grid).Parent as Grid;
            double height = gridCase.Height + 10; // the DC shift to account for the margin. 

            stackPanelOuter.Children.Remove(gridCase);

            DoubleAnimation resizeBlockAnimation = new DoubleAnimation(this.Height, this.Height - height, new Duration(TimeSpan.FromSeconds(.1)));
            this.BeginAnimation(HeightProperty, resizeBlockAnimation);
        }

        public override string ToExecString()
        {
            string s = Utilities.indent + "switch (" + textBoxSwitchVariable.Text + ")\n" + Utilities.indent + "{\n";
            Utilities.indent += "\t";
            AppendToCodeBlock(s);

            // temp variables
            Grid gridCase = new Grid();
            Border br;
            TextBox tx = new TextBox();

            if (stackPanelOuter.Children.Count > 4)
            {
                for (int i = 3; i < stackPanelOuter.Children.Count - 1; i++)
                {

                    gridCase = (Grid)stackPanelOuter.Children[i];
                    Grid caseStatementGrid = (Grid)gridCase.Children[0];
                    br = (Border)caseStatementGrid.Children[1];

                    s += Utilities.indent + "case " + ((TextBox)br.Child).Text + ":\n";

                    AppendToCodeBlock(Utilities.indent + "case " + ((TextBox)br.Child).Text + ":\n");
                    Utilities.indent += "\t";

                    br = (Border)gridCase.Children[1];
                    foreach (BlockBase child in ((StackPanel)br.Child).Children)
                        s += Utilities.indent + child.ToExecString();

                    s += Utilities.indent + "break;\n";
                    AppendToCodeBlock(Utilities.indent + "break;\n");
                    Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);
                }
            }

            gridCase = (Grid)stackPanelOuter.Children[stackPanelOuter.Children.Count - 1];
            br = (Border)gridCase.Children[1];
            if (((StackPanel)br.Child).Children.Count > 0)
            {
                s += Utilities.indent + "default :\n";

                AppendToCodeBlock(Utilities.indent + "default :\n");
                Utilities.indent += "\t";

                foreach (BlockBase child in ((StackPanel)br.Child).Children)
                    s += Utilities.indent + child.ToExecString();

                s += Utilities.indent + "break;\n";
                AppendToCodeBlock(Utilities.indent + "break;\n");
                Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);
            }

            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);
            s += Utilities.indent + "}\n";
            AppendToCodeBlock(Utilities.indent + "}\n");

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Switch");
            x.WriteAttributeString("switchVariable", textBoxSwitchVariable.Text);

            // temp variables
            Grid gridCase = new Grid();
            Border br;
            TextBox tx = new TextBox();

            if (stackPanelOuter.Children.Count > 4)
            {
                for (int i = 3; i < stackPanelOuter.Children.Count - 1; i++)
                {
                    gridCase = (Grid)stackPanelOuter.Children[i];

                    Grid caseStatementGrid = (Grid)gridCase.Children[0];
                    br = (Border)caseStatementGrid.Children[1];
                    string caseStatment = ((TextBox)br.Child).Text;

                    br = (Border)gridCase.Children[1];
                    x.WriteStartElement("c");
                    x.WriteAttributeString("String", caseStatment);

                    if (((StackPanel)br.Child).Children.Count > 0)
                    {
                        x.WriteStartElement("InnerBlocks");
                        foreach (BlockBase block in ((StackPanel)br.Child).Children)
                            block.ToXml(x);

                        x.WriteEndElement(); //</innerBlocks>
                    }
                    x.WriteEndElement(); // </c>
                }
            }

            gridCase = (Grid)stackPanelOuter.Children[stackPanelOuter.Children.Count - 1];
            br = (Border)gridCase.Children[1];

            x.WriteStartElement("Default");
            x.WriteStartElement("InnerBlocks");

            foreach (BlockBase block in ((StackPanel)br.Child).Children)
                block.ToXml(x);

            x.WriteEndElement(); // </innerblocks>
            x.WriteEndElement(); // </default>

            x.WriteEndElement(); // </Switch>
        }

        public override void FromXml(XmlNode node)
        {
            textBoxSwitchVariable.Text = HttpUtility.HtmlDecode(node.Attributes["switchVariable"].Value);

            // temp variables
            Grid gridCase = new Grid();
            Border br;
            TextBox tx = new TextBox();
            StackPanel stackPanelBody = new StackPanel();
            BlockBase newBlock = new BlockBase();

            // switch cases
           
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (i < node.ChildNodes.Count - 1) // cases
                {
                    // add a new parameter through raising the add parameter button click event programmatically
                    RoutedEventArgs e = new RoutedEventArgs(Button.ClickEvent, buttonAddCase);
                    buttonAddCase.RaiseEvent(e);

                    // case statement (header)
                    gridCase = (Grid)stackPanelOuter.Children[i + 3];
                    Grid caseStatementGrid = (Grid)gridCase.Children[0];
                    br = (Border)caseStatementGrid.Children[1];

                    // at last!
                    ((TextBox)br.Child).Text = HttpUtility.HtmlDecode(node.ChildNodes[i].Attributes["String"].Value);

                    // case body itself!!
                    br = (Border)gridCase.Children[1];
                    stackPanelBody = (StackPanel)br.Child;
                }
                else // default
                    stackPanelBody = stackPanelDefault;

                if (node.ChildNodes[i].ChildNodes.Count > 0 && node.ChildNodes[i].ChildNodes[0].ChildNodes.Count > 0)
                {
                    foreach (XmlNode innerNode in node.ChildNodes[i].ChildNodes[0].ChildNodes)
                    {
                        switch (innerNode.Name)
                        {
                            case "Variable":
                                newBlock = new VariableBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;

                            case "Statement":
                                newBlock = new StatementBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;

                            case "IfThenElse":
                                newBlock = new ifThenElseBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;

                            case "For":
                                newBlock = new ForBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;

                            case "Switch":
                                newBlock = new SwitchBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;

                            case "Input":
                                newBlock = new InputBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;

                            case "Output":
                                newBlock = new OutputBlock();
                                newBlock.FromXml(innerNode); // initialize the block with save values

                                stackPanelBody.Children.Add(newBlock);
                                break;
                        } //switch 

                        newBlock.Margin = new Thickness(10, 10, 0, 0);
                        newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    } // foreach
                }
            } // for 

        } // FromXml

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.switchString;
            else
                gridHeader.ToolTip = "switch block";
        }

        private void textBoxSwitchVariable_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxSwitchVariable.ToolTip = Utilities.switchVariable;
            else
                textBoxSwitchVariable.ToolTip = "variable";
        }

        private void AddCase_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                AddCase.ToolTip = Utilities.switchcase;
            else
                AddCase.ToolTip = "add case";
        }

        private void textBoxDefaultCase_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxDefaultCase.ToolTip = Utilities.switchDefaultCase;
            else
                textBoxDefaultCase.ToolTip = "default";
        } 

    }
}
