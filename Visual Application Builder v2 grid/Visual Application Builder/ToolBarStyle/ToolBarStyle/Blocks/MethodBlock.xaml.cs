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
using VisualApplicationBuilder.Block;
using System.Xml;
using System.Web;

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MethodBlock : BlockBase
    {
        public MethodBlock()
        {
            InitializeComponent();
            this.MinWidth = 500;

            // wiring events to their handlers
            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            this.SizeChanged += blockControl_SizeChanged;

            stackPanelBody.DragEnter += stackPanel_DragEnter;
            stackPanelBody.Drop += stackPanel_Drop;

            buttonHighlight.Click += buttonHighlight_Click;

            FillComboBoxes();
            FillModifier();
        }

        public void FillComboBoxes()
        {
            #region Filling the comboBoxes using Reflection
            //object s = new object();
            //Assembly thePrimitiveAssembly = Assembly.Load("mscorlib");
            //Type[] thePrimitiveAssembly_Types = thePrimitiveAssembly.GetTypes();
            //foreach (var item in thePrimitiveAssembly_Types)
            //{
            //    if (item.IsPrimitive == true)
            //    {
            //        comboboxReturnType.Items.Add(item);
            //        comboboxParameterDataType.Items.Add(item);
            //    }
            //}
            #endregion

            // manually filling the comboBoxes
            comboboxReturnType.Items.Add("void");
            comboboxReturnType.Items.Add("Other");
            comboboxReturnType.Items.Add("bool");
            comboboxReturnType.Items.Add("int");
            comboboxReturnType.Items.Add("double");
            comboboxReturnType.Items.Add("char");
            comboboxReturnType.Items.Add("string");

            comboboxParameterDataType.Items.Add("Other");
            comboboxParameterDataType.Items.Add("bool");
            comboboxParameterDataType.Items.Add("int");
            comboboxParameterDataType.Items.Add("double");
            comboboxParameterDataType.Items.Add("char");
            comboboxParameterDataType.Items.Add("string");

            comboboxReturnType.SelectedIndex = 0;
            comboboxParameterDataType.SelectedIndex = 0;
        }
        public void FillModifier()
        {
            comboboxModifier.Items.Add("public");
            comboboxModifier.Items.Add("protected");
            comboboxModifier.Items.Add("private");
            comboboxModifier.Items.Add("public static");
            comboboxModifier.Items.Add("protected static");
            comboboxModifier.Items.Add("private static");

            comboboxModifier.SelectedIndex = 0;
        }

        private void buttonAddParameter_Click(object sender, RoutedEventArgs e)
        {
            #region Controls

            // border 
            Border borderParam = new Border();
            borderParam.BorderThickness = new Thickness(1);
            borderParam.BorderBrush = (SolidColorBrush)Application.Current.Resources["BorderBrush2"];
            borderParam.Background = (SolidColorBrush)Application.Current.Resources["BackgroundBrush"];
            borderParam.Height = 25;
            borderParam.Margin = new Thickness(10, 10, 10, 0);

            // create a label holding the parameter information
            Label param = new Label();
            param.Padding = new Thickness(2);
            param.Foreground = (SolidColorBrush)Application.Current.Resources["DisabledBackgroundBrush"];

            string type = comboboxParameterDataType.SelectedValue.ToString();
            if (type == "Other")
                type = "";

            param.Content = type + " " + TextboxParameterName.Text;

            // create a button to remove the parameter
            Button removeParameter = new Button();
            removeParameter.Click += removeParameter_Click;

            #region programmatically creating the button
            //DrawingBrush dBrush = new DrawingBrush();
            //DrawingGroup dGroup = new DrawingGroup();
            //Pen p = new Pen(new SolidColorBrush(Colors.Black), 4);

            //GeometryDrawing gDrawingEllipse = new GeometryDrawing();
            //gDrawingEllipse.Geometry = new EllipseGeometry(new Point(0, 0), 15, 15);
            //gDrawingEllipse.Pen = p;

            //GeometryDrawing gDrawingMinus = new GeometryDrawing();

            //PathGeometry pGeometryMinus = new PathGeometry();
            //PathFigure pFigure = new PathFigure();
            //pFigure.StartPoint = new Point(-7, 0);
            //pFigure.Segments.Add(new LineSegment(new Point(7, 0), true));
            //pFigure.IsClosed = false;
            //pGeometryMinus.Figures.Add(pFigure);

            //gDrawingMinus.Geometry = pGeometryMinus;
            //gDrawingMinus.Pen = p;

            //dGroup.Children.Add(gDrawingEllipse);
            //dGroup.Children.Add(gDrawingMinus);

            //dBrush.Drawing = dGroup;
            #endregion

            // button attributes
            removeParameter.OpacityMask = (DrawingBrush)Application.Current.Resources["RemoveParameterButtonBrush"];
            removeParameter.Background = (SolidColorBrush)Application.Current.Resources["RedBrush"];
            removeParameter.Width = 23;
            removeParameter.Height = 23;
            removeParameter.Margin = new Thickness(0, 0, 10, 0);
            removeParameter.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            removeParameter.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            removeParameter.Style = (Style)Application.Current.Resources["AlphaButtonStyle"];

            #endregion

            // adding the label and the button to a grid
            System.Windows.Controls.Grid g = new System.Windows.Controls.Grid();
            g.Children.Add(param);
            g.Children.Add(removeParameter);

            // add the grid as a child of the border and add the border to the parameter stackpanel.
            borderParam.Child = g;
            stackPanelParameters.Children.Insert(stackPanelParameters.Children.Count - 1, borderParam);
        }

        private void removeParameter_Click(object sender, RoutedEventArgs e)
        {
            // remove from children collection of the stackPanel
            Border parent = ((e.Source as Button).Parent as System.Windows.Controls.Grid).Parent as Border;

            stackPanelParameters.Children.Remove(parent);
            // resize the stackPanel!!!
        }

        public override string ToExecString()
        {
            string s;

            string returnType = comboboxReturnType.SelectedValue.ToString();
            if (returnType == "Other")
                returnType = "";

            s = Utilities.indent + comboboxModifier.SelectedValue.ToString() + " " + returnType + " " + textBoxMethodName.Text + "(";

            // parameters
            if (stackPanelParameters.Children.Count > 3) // the method takes parameters
            {
                for (int i = 2; i <= stackPanelParameters.Children.Count - 2; i++)
                {
                    Border br = (Border)stackPanelParameters.Children[i];
                    System.Windows.Controls.Grid gr = (System.Windows.Controls.Grid)br.Child;
                    s += ((Label)gr.Children[0]).Content.ToString();

                    if (i < stackPanelParameters.Children.Count - 2)
                        s += ", ";
                }
            }
            
            s += ")\n" + Utilities.indent + "{\n";
            AppendToCodeBlock(s);

            Utilities.indent += "\t";
               
            foreach (BlockBase child in stackPanelBody.Children)
                s += child.ToExecString();

            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);

            s += Utilities.indent + "}\n";
            AppendToCodeBlock(Utilities.indent + "}\n");

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Method");
            x.WriteAttributeString("Modifier", comboboxModifier.SelectedValue.ToString());

            string returnType = comboboxReturnType.SelectedValue.ToString();
            if (returnType == "Other")
                returnType = "";

            x.WriteAttributeString("ReturnType", returnType);
            x.WriteAttributeString("MethodName", textBoxMethodName.Text);

            x.WriteStartElement("Parameters");
            // parameters
            if (stackPanelParameters.Children.Count > 3) // the method takes parameters
            {
                for (int i = 2; i <= stackPanelParameters.Children.Count - 2; i++)
                {
                    Border br = (Border)stackPanelParameters.Children[i];
                    System.Windows.Controls.Grid gr = (System.Windows.Controls.Grid)br.Child;
                    
                    string p = ((Label)gr.Children[0]).Content.ToString();
                    if (p == "Other") // don't take the value of the "Other" selection. 
                        p = "";

                    x.WriteStartElement("p");
                    x.WriteAttributeString("String", p);
                    x.WriteEndElement();
                }
            }
            x.WriteEndElement(); // </Parameters>
            
            x.WriteStartElement("InnerBlocks");
            foreach (BlockBase block in stackPanelBody.Children)
                block.ToXml(x);

            x.WriteEndElement(); // </InnerBlocks>
            x.WriteEndElement(); // </Method>
        }

        public override void FromXml(XmlNode node)
        {
            comboboxModifier.SelectedIndex = comboboxModifier.Items.IndexOf(node.Attributes["Modifier"].Value);

            if (node.Attributes["ReturnType"].Value != "")
                comboboxReturnType.SelectedIndex = comboboxReturnType.Items.IndexOf(node.Attributes["ReturnType"].Value);
            else
                comboboxReturnType.SelectedIndex = 1;

            textBoxMethodName.Text = HttpUtility.HtmlDecode( node.Attributes["MethodName"].Value);

            // method parameters
            XmlNode parametersNode = node.ChildNodes[0];
            for (int i = 0; i < parametersNode.ChildNodes.Count; i++)
            {
                // add a new parameter through raising the add parameter button click event programmatically
                RoutedEventArgs e = new RoutedEventArgs(Button.ClickEvent, buttonAddParameter);
                buttonAddParameter.RaiseEvent(e);

                Border br = (Border)stackPanelParameters.Children[i + 2];
                System.Windows.Controls.Grid gr = (System.Windows.Controls.Grid)br.Child;
                Label temp = ((Label)gr.Children[0]);
                ((Label)gr.Children[0]).Content = HttpUtility.HtmlDecode( parametersNode.ChildNodes[i].Attributes["String"].Value);
            }

            BlockBase newBlock = new BlockBase();
            foreach (XmlNode innerNode in node.ChildNodes[1])
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
                }
                newBlock.Margin = new Thickness(10, 10, 0, 0);
                newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            } // foreach
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.methodString;
            else
                gridHeader.ToolTip = "method block";
        }

        private void comboboxModifier_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxModifier.ToolTip = Utilities.methodModifier;
            else
                comboboxModifier.ToolTip = "modifier";
        }

        private void comboboxReturnType_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxReturnType.ToolTip = Utilities.methodReturnType;
            else
                comboboxReturnType.ToolTip = "return type";
        }

        private void textBoxMethodName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxMethodName.ToolTip = Utilities.methodName;
            else
                textBoxMethodName.ToolTip = "name";
        }

        private void comboboxParameterDataType_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxParameterDataType.ToolTip = Utilities.methodparameterDataType;
            else
                comboboxParameterDataType.ToolTip = "data type";
        }

        private void TextboxParameterName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                TextboxParameterName.ToolTip = Utilities.methodparameterName;
            else
                TextboxParameterName.ToolTip = "name";
        }
    }

}
