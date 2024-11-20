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
    public partial class FromFileBlock : BlockBase
    {
        public FromFileBlock()
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
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text files (*.txt)|*.txt";
            openDialog.ShowDialog();
            textBoxFileName.Text = openDialog.FileName;
        }

        public override string ToExecString()
        {
            string s = "";

            if (File.Exists(textBoxFileName.Text))
                s = Utilities.indent + textBoxVariable.Text + " = File.ReadAllText(" + textBoxFileName.Text + ");\n";

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
            x.WriteAttributeString("Variable", textBoxVariable.Text);
            x.WriteEndElement();
        }

        public override void FromXml(XmlNode node)
        {
            textBoxVariable.Text = HttpUtility.HtmlDecode( node.Attributes["Variable"].Value);
            textBoxFileName.Text = HttpUtility.HtmlDecode( node.Attributes["Path"].Value);
        }
    }
}
