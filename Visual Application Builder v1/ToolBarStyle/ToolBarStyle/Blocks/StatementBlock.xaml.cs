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
    public partial class StatementBlock : ResourceClasses.BlockBase
    {
        public StatementBlock()
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
            string s = textBoxStatement.Text;

            if (s.Length == 0 || s[s.Length - 1] != ';')
                s += ";";

            s = Utilities.indent + s + "\n";
            AppendToCodeBlock(s);

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Statement");
            x.WriteAttributeString("String", textBoxStatement.Text);
            x.WriteEndElement();
        }

        public override void FromXml(XmlNode node)
        {
            textBoxStatement.Text =  HttpUtility.HtmlDecode(node.Attributes["String"].Value);
        }

        public override double CalculateHeight()
        {
            return 75.541;
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.statementText;
            else
                gridHeader.ToolTip = "statement block";
        }

        private void textBoxStatement_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.statementText;
            else
                gridHeader.ToolTip = "output block";
        }
    }

}
