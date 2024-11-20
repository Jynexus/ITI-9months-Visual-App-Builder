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
using System.Xml;
using VisualApplicationBuilder.ResourceClasses;
using System.Web;

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ClassBlock : ResourceClasses.BlockBase
    {
        //
        // constructor
        //
        public ClassBlock()
        {
            InitializeComponent();

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

            fillModifierComboBox();
            comboboxModifier.SelectedIndex = 0;

            // place holders
            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";
        }
        //
        // utility methods
        //
        public void fillModifierComboBox()
        {
            comboboxModifier.Items.Add("public");
            comboboxModifier.Items.Add("protected");
            comboboxModifier.Items.Add("private");

            comboboxModifier.Items.Add("public static");
            comboboxModifier.Items.Add("protected static");
            comboboxModifier.Items.Add("private static");
        }
        
        public override string ToExecString()
        {
            string s;

            s = Utilities.indent + comboboxModifier.SelectedItem + " class " + textBoxName.Text + "\n" + Utilities.indent + "{\n";

            // append the text to textBlockCode
            AppendToCodeBlock(s);
            
            Utilities.indent += "\t";
            foreach (ResourceClasses.BlockBase block in stackPanelBody.Children)
                s += block.ToExecString();

            // remove the indent
            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);
            
            s += Utilities.indent + "}\n";
            AppendToCodeBlock(Utilities.indent + "}\n");
                
            return s;
        }

        public override void ToXml (XmlWriter x)
        {
            x.WriteStartElement("Class");
            x.WriteAttributeString("Modifier", comboboxModifier.SelectedValue.ToString());
            x.WriteAttributeString("ClassName", textBoxName.Text);

            x.WriteStartElement("InnerBlocks");
            foreach (BlockBase block in stackPanelBody.Children)
                block.ToXml(x);

            x.WriteEndElement(); // </InnerBlocks>
            x.WriteEndElement(); // </Class>
        }

        public override void FromXml(XmlNode node)
        {
            comboboxModifier.SelectedIndex = comboboxModifier.Items.IndexOf(node.Attributes["Modifier"].Value);
            textBoxName.Text = HttpUtility.HtmlDecode(node.Attributes["ClassName"].Value);
            
            // this foreach should be implemented as a separate method - no easy way to do that!! It's ugly. I know!
            BlockBase newBlock = new BlockBase();
            foreach (XmlNode innerNode in node.ChildNodes[0])
            {
                switch (innerNode.Name)
                {
                    case "Class":
                        newBlock = new ClassBlock();
                        newBlock.FromXml(innerNode); // initialize the block with save values

                        stackPanelBody.Children.Add(newBlock);
                        break;

                    case "Struct":
                        newBlock = new StructBlock();
                        newBlock.FromXml(innerNode); // initialize the block with save values

                        stackPanelBody.Children.Add(newBlock);
                        break;

                    case "Method":
                        newBlock = new MethodBlock();
                        newBlock.FromXml(innerNode); // initialize the block with save values

                        stackPanelBody.Children.Add(newBlock);
                        break;

                    case "Variable":
                        newBlock = new VariableBlock();
                        newBlock.FromXml(innerNode); // initialize the block with save values

                        stackPanelBody.Children.Add(newBlock);
                        break;
                }

                newBlock.Margin = new Thickness(10, 10, 0, 0);
                newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            } // foreach

        } // FromXml()
    }

}