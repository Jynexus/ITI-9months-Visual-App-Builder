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
    /// Interaction logic for InputBlock.xaml
    /// </summary>
    public partial class InputBlock : BlockBase
    {
        public InputBlock()
        {
            InitializeComponent();

            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            buttonHighlight.Click += buttonHighlight_Click;
        }

        public override string ToExecString()
        {
            string s;

            if (comboBoxDataType.SelectedValue.ToString() != "string")
                s = Utilities.indent + textBoxVariable.Text + " = " + comboBoxDataType.SelectedValue.ToString() + ".Parse(Console.ReadLine());\n";

            else
                s = Utilities.indent + textBoxVariable.Text + " = Console.ReadLine();\n";

            AppendToCodeBlock(s);

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Input");
            x.WriteAttributeString("Variable", textBoxVariable.Text);
            x.WriteEndElement();
        }

        public override void FromXml(XmlNode node)
        {
            textBoxVariable.Text = HttpUtility.HtmlDecode( node.Attributes["Variable"].Value);
        }
    }
}
