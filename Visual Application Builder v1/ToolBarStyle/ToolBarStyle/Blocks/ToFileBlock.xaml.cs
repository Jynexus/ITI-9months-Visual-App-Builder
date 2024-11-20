using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for FromFile.xaml
    /// </summary>
    public partial class ToFileBlock : BlockBase
    {
        public ToFileBlock()
        {
            InitializeComponent();

            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            buttonHighlight.Click += buttonHighlight_Click;
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text files (*.txt)|*.txt";
            saveDialog.ShowDialog();
            textBoxFileName.Text = saveDialog.FileName;
        }

        public override string ToExecString()
        {
            string s = "";

            if (File.Exists(textBoxFileName.Text))
                s = Utilities.indent + "File.WriteAllText(" + textBoxFileName.Text + ", " + textBoxContent.Text + ");\n";

            else
            {
                Window window = new BlocksAll.CustomMessageBox("Path error", "File doesn't exist");
                window.ShowDialog();
            }

            AppendToCodeBlock(s);

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("FromFile");
            x.WriteAttributeString("Path", textBoxFileName.Text);
            x.WriteAttributeString("Content", textBoxContent.Text);
            x.WriteEndElement();
        }

        public override void FromXml(XmlNode node)
        {
            textBoxContent.Text = HttpUtility.HtmlDecode( node.Attributes["Content"].Value);
            textBoxFileName.Text =  HttpUtility.HtmlDecode(node.Attributes["Path"].Value);
        }

        public override double CalculateHeight()
        {
            return 114.144;
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.tofileString;
            else
                gridHeader.ToolTip = "to file block";
        }

        private void textBoxFileName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxFileName.ToolTip = Utilities.toFileName;
            else
                textBoxFileName.ToolTip = "name";
        }

        private void textBoxContent_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxContent.ToolTip = Utilities.toContent;
            else
                textBoxContent.ToolTip = "content";
        }
    }
}
