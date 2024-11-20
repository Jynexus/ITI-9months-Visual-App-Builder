using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StructBlock : ResourceClasses.BlockBase
    {
        public StructBlock()
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

            s = Utilities.indent + comboboxModifier.SelectedItem + textBoxName.Text + "\n" + Utilities.indent + "{\n";
            AppendToCodeBlock(s);

            Utilities.indent += "\t";
            foreach (ResourceClasses.BlockBase block in stackPanelBody.Children)
                s += block.ToExecString();

            // remove the tab
            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);
            
            s += Utilities.indent + "}\n";
            AppendToCodeBlock(Utilities.indent + "}\n");

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Struct");
            x.WriteAttributeString("Modifier", comboboxModifier.SelectedValue.ToString());
            x.WriteAttributeString("StructName", textBoxName.Text);

            x.WriteStartElement("InnerBlocks");
            foreach (BlockBase block in stackPanelBody.Children)
                block.ToXml(x);

            x.WriteEndElement(); // </InnerBlocks>
            x.WriteEndElement(); // </Struct>
        }

        public override void FromXml(XmlNode node)
        {
            comboboxModifier.SelectedIndex = comboboxModifier.Items.IndexOf(node.Attributes["Modifier"].Value);
            textBoxName.Text =  HttpUtility.HtmlDecode(node.Attributes["StructName"].Value);

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

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.structString;
            else
                gridHeader.ToolTip = "struct block";
        }

        private void comboboxModifier_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxModifier.ToolTip = Utilities.structModifier;
            else
                comboboxModifier.ToolTip = "modifier";
        }

        private void textBoxName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxName.ToolTip = Utilities.structName;
            else
                textBoxName.ToolTip = "name";
        } 
    }

}
