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
    public partial class WhileBlock : ResourceClasses.BlockBase
    {
        public WhileBlock()
        {
            InitializeComponent();

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

            string s = Utilities.indent + "while (" + textBoxCondition.Text + ")\n";
            s += Utilities.indent + "{\n";

            AppendToCodeBlock(s);

            var children = stackPanelBody.Children;
            Utilities.indent += "\t";
            foreach (ResourceClasses.BlockBase child in children)
                s += Utilities.indent + child.ToExecString();

            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);
            s += Utilities.indent + "}\n";

            AppendToCodeBlock(Utilities.indent + "}\n");

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("While");
            x.WriteAttributeString("Condition", textBoxCondition.Text);

            x.WriteStartElement("InnerBlocks");
            foreach (BlockBase block in stackPanelBody.Children)
                block.ToXml(x);

            x.WriteEndElement(); // </InnerBlocks>
            x.WriteEndElement(); // </For>
        }

        public override void FromXml(XmlNode node)
        {
            textBoxCondition.Text = HttpUtility.HtmlDecode(node.Attributes["Condition"].Value);

            BlockBase newBlock = new BlockBase();
            foreach (XmlNode innerNode in node.ChildNodes[0])
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

        public override double CalculateHeight()
        {
            double height = 313 - 197 + 20;

            var children = stackPanelBody.Children;
            foreach (ResourceClasses.BlockBase child in children)
                height += child.CalculateHeight();

            return height;
        }

        private void textBoxCondition_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxCondition.ToolTip = Utilities.forCondition;
            else
                textBoxCondition.ToolTip = "condition";
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.forString;
            else
                gridHeader.ToolTip = "for block";
        }
    }

}
