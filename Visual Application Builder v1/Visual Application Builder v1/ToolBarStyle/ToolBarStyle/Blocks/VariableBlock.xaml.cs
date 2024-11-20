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
using VisualApplicationBuilder.ResourceClasses;
using System.Reflection;
using System.Xml;
using System.Web;

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class VariableBlock : ResourceClasses.BlockBase
    {
        public VariableBlock()
        {
            InitializeComponent();

            // wiring events to their handlers
            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            buttonHighlight.Click += buttonHighlight_Click;

            comboboxComplexType.Items.Clear();
            comboboxComplexType.Items.Add("bool");
            comboboxComplexType.Items.Add("int");
            comboboxComplexType.Items.Add("double");
            comboboxComplexType.Items.Add("char");
            comboboxComplexType.Items.Add("string");

            comboboxComplexType.SelectedIndex = 0;

            #region filling the comboBox using Reflection
            //Assembly thePrimitiveAssembly = Assembly.Load("mscorlib");
            //Type[] thePrimitiveAssembly_Types = thePrimitiveAssembly.GetTypes();
            //foreach (var item in thePrimitiveAssembly_Types)
            //    if (item.IsPrimitive)
            //        comboboxComplexType.Items.Add(item);
            #endregion
        }

        private void checkboxComplexType_Check(object sender, RoutedEventArgs e)
        {
            if (checkboxComplexType.IsChecked == true)
                comboboxComplexType.IsEnabled = false;
            
            else
                comboboxComplexType.IsEnabled = true;
        }

        public override string ToExecString()
        {
            string s;
            
            if (checkboxComplexType.IsChecked == true)
                s = Utilities.indent + textBoxIdentifier.Text;

            else
                s = Utilities.indent + comboboxComplexType.SelectedValue.ToString() + " " + textBoxIdentifier.Text;

            if (s.Length == 0 || s[s.Length - 1] != ';')
                s += ";";

            s += "\n";

            AppendToCodeBlock(s);

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Variable");

            x.WriteAttributeString("CheckComplex", checkboxComplexType.IsChecked.ToString());

            if (checkboxComplexType.IsChecked == false)
                x.WriteAttributeString("Type", comboboxComplexType.SelectedValue.ToString());

            x.WriteAttributeString("Identifier", textBoxIdentifier.Text);
            
            x.WriteEndElement(); // </Variable>
        }

        public override void FromXml(XmlNode node)
        {
            if (node.Attributes["CheckComplex"].Value == "True")
                checkboxComplexType.IsChecked = true;
            else
            {
                checkboxComplexType.IsChecked = false;
                comboboxComplexType.SelectedIndex = comboboxComplexType.Items.IndexOf(node.Attributes["Type"].Value);
            }

            textBoxIdentifier.Text = HttpUtility.HtmlDecode( node.Attributes["Identifier"].Value);
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.variableString;
            else
                gridHeader.ToolTip = "variable block";
        }

        private void checkboxComplexType_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Utilities.helpActive)
                checkboxComplexType.ToolTip = Utilities.variableComplex;
            else
                checkboxComplexType.ToolTip = "complex?";
        }

        private void comboboxComplexType_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxComplexType.ToolTip = Utilities.variableType;
            else
                comboboxComplexType.ToolTip = "data type";
        }

        private void textBoxIdentifier_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                textBoxIdentifier.ToolTip = Utilities.variableIdentifier;
            else
                textBoxIdentifier.ToolTip = "name";
        }

    }
}
