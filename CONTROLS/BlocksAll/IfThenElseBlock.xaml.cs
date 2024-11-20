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
    public partial class ifThenElseBlock : ResourceClasses.BlockBase
    {
        public ifThenElseBlock()
        {
            InitializeComponent();

            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            this.SizeChanged += blockControl_SizeChanged;

            stackPanelThen.DragEnter += stackPanel_DragEnter;
            stackPanelThen.Drop += stackPanel_Drop;

            stackPanelElse.DragEnter += stackPanel_DragEnter;
            stackPanelElse.Drop += stackPanel_Drop;

            buttonHighlight.Click += buttonHighlight_Click;

            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";
        }

        public override string ToExecString()
        {
            string s = Utilities.indent + "if (" + textBoxCondition.Text + ")\n" + Utilities.indent + "{\n";

            // append the text to textBlockCode
            AppendToCodeBlock(s);

            var children = stackPanelThen.Children;

            Utilities.indent += "\t";
            foreach (ResourceClasses.BlockBase child in children)
                s += child.ToExecString();

            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);

            AppendToCodeBlock(Utilities.indent + "}\n");

            if (stackPanelElse.Children.Count > 0)
            {
                s += Utilities.indent + "else\n" + Utilities.indent + "{\n";

                AppendToCodeBlock(Utilities.indent + "else\n" + Utilities.indent + "{\n");

                children = stackPanelElse.Children;

                Utilities.indent += "\t";
                foreach (ResourceClasses.BlockBase child in children)
                    s += child.ToExecString();

                Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 1);

                s += Utilities.indent + "}\n";

                AppendToCodeBlock(Utilities.indent + "}\n");
            }

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("IfThenElse");
            x.WriteAttributeString("Condition", textBoxCondition.Text);

            x.WriteStartElement("ThenInnerBlocks");
            foreach (BlockBase block in stackPanelThen.Children)
                block.ToXml(x);

            x.WriteEndElement(); // </ThenInnerBlocks>

            if (stackPanelElse.Children.Count > 0)
            {
                x.WriteStartElement("ElseInnerBlocks");
                foreach (BlockBase block in stackPanelElse.Children)
                    block.ToXml(x);

                x.WriteEndElement(); // </ElseInnerBlocks>
            }

            x.WriteEndElement(); // </IfThenElse>
        }
        public override void FromXml(XmlNode node)
        {
            textBoxCondition.Text = HttpUtility.HtmlDecode( node.Attributes["Condition"].Value);

            StackPanel[] stackPanelBody = new StackPanel[2];
            stackPanelBody[0] = stackPanelThen;
            stackPanelBody[1] = stackPanelElse;

            BlockBase newBlock = new BlockBase();
            for (int u = 0; u < 2; u++ )
                foreach (XmlNode innerNode in node.ChildNodes[u]) // loops the Then stackPanel, then the Else stackPanel
                {
                    switch (innerNode.Name)
                    {
                        case "Variable":
                            newBlock = new VariableBlock();
                            newBlock.FromXml(innerNode); // initialize the block with save values

                            stackPanelBody[u].Children.Add(newBlock);
                            break;

                        case "Statement":
                            newBlock = new StatementBlock();
                            newBlock.FromXml(innerNode);

                            stackPanelBody[u].Children.Add(newBlock);
                            break;

                        case "IfThenElse":
                            newBlock = new ifThenElseBlock();
                            newBlock.FromXml(innerNode);

                            stackPanelBody[u].Children.Add(newBlock);
                            break;

                        case "For":
                            newBlock = new ForBlock();
                            newBlock.FromXml(innerNode);

                            stackPanelBody[u].Children.Add(newBlock);
                            break;

                        case "Switch":
                            newBlock = new SwitchBlock();
                            newBlock.FromXml(innerNode);

                            stackPanelBody[u].Children.Add(newBlock);
                            break;

                        case "Input":
                            newBlock = new InputBlock();
                            newBlock.FromXml(innerNode);

                            stackPanelBody[u].Children.Add(newBlock);
                            break;

                        case "Output":
                            newBlock = new OutputBlock();
                            newBlock.FromXml(innerNode);

                            stackPanelBody[u].Children.Add(newBlock);
                            break;
                    }

                    newBlock.Margin = new Thickness(10, 10, 0, 0);
                    newBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                } // foreach

        }
    }

}
