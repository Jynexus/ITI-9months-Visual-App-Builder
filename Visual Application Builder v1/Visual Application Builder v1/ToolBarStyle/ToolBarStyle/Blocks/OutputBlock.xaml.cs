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
    /// Interaction logic for OutputBlock.xaml
    /// </summary>
    public partial class OutputBlock : BlockBase
    {
        public OutputBlock()
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
            string s = Utilities.indent + "Console.WriteLine (" + textBoxOutput.Text + ");\n";
            AppendToCodeBlock(s);

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Output");
            x.WriteAttributeString("String", textBoxOutput.Text);
            x.WriteEndElement();
        }

        public override void FromXml(XmlNode node)
        {
            textBoxOutput.Text =  HttpUtility.HtmlDecode(node.Attributes["String"].Value);
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.outputString;
            else
                gridHeader.ToolTip = "output block";
        }

        private void textBoxOutput_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxOutput.ToolTip = Utilities.outputText;
            else
                textBoxOutput.ToolTip = "text";
        }
    }
}
