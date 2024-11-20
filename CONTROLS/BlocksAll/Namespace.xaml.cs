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

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NamespaceBlock : ResourceClasses.BlockBase
    {
        public NamespaceBlock()
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

            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";
        }

        public override string ToExecString()
        {
            string s = Utilities.indent + "namespace " + textBoxName.Text + "\n" + Utilities.indent + "{\n";
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
            x.WriteStartElement("Namespace");
            x.WriteAttributeString("Name", textBoxName.Text);

            x.WriteStartElement("InnerBlocks");
            foreach (BlockBase block in stackPanelBody.Children)
                block.ToXml(x);

            x.WriteEndElement(); // </InnerBlocks>
            x.WriteEndElement(); // </Namespace>
        }

        public override void FromXml(XmlNode node)
        {
            textBoxName.Text = node.Attributes["Name"].Value;

            // this foreach should be implemented as a separate method - no easy way to do that!! It's ugly. I know!
            BlockBase newBlock = new BlockBase();
            foreach (XmlNode innerNode in node.ChildNodes[0])
            {
                switch (innerNode.Name)
                {
                    case "Namespace":
                        newBlock = new NamespaceBlock();
                        newBlock.FromXml(innerNode); // initialize the block with save values

                        stackPanelBody.Children.Add(newBlock);
                        break;

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
                }

                newBlock.Margin = new Thickness(10, 10, 0, 0);
                newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            } // foreach
        } // FromXml()
    }

}
