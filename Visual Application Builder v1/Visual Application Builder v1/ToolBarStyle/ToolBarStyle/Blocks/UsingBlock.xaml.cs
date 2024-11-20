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

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UsingBlock : ResourceClasses.BlockBase
    {
        public UsingBlock()
        {
            InitializeComponent();

            // wiring events to their handlers
            buttonRemoveBlock.Click += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.gridHeader.MouseLeftButtonDown += Block_MouseLeftButtonDown;
            this.gridHeader.Drop += stackPanel_Drop;
            this.MouseLeftButtonUp += Block_MouseLeftButtonUp;
            this.MouseMove += Block_MouseMove;

            this.SizeChanged += blockControl_SizeChanged;

            buttonHighlight.Click += buttonHighlight_Click;

            comboboxMainNS.Items.Add("Fundamentals");
            comboboxMainNS.Items.Add("WPF & Windows Forms");
            comboboxMainNS.Items.Add("Data, XML and LINQ");
            comboboxMainNS.Items.Add("Microsoft");
            comboboxMainNS.SelectedIndex = 0;
        }

        private void comboboxMainNS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)comboboxMainNS.SelectedValue == "Fundamentals")
            {
                comboboxNSS.Items.Clear();
                comboboxNSS.Items.Add("System");
                comboboxNSS.Items.Add("System.AddIn.Contract");
                comboboxNSS.Items.Add("System.AddIn.Hosting");
                comboboxNSS.Items.Add("System.AddIn.Pipeline");
                comboboxNSS.Items.Add("System.Collections");
                comboboxNSS.Items.Add("System.Collections.Generic");
                comboboxNSS.Items.Add("System.ComponentModel");
                comboboxNSS.Items.Add("System.Configuration");
                comboboxNSS.Items.Add("System.Diagnostics");
                comboboxNSS.Items.Add("System.Diagnostics.Eventing");
                comboboxNSS.Items.Add("System.Diagnostics.Eventing.Reader");
                comboboxNSS.Items.Add("System.Diagnostics.PerformanceData");
                comboboxNSS.Items.Add("System.DirectoryServices");
                comboboxNSS.Items.Add("System.DirectoryServices.ActiveDirectory");
                comboboxNSS.Items.Add("System.EnterpriseServices");
                comboboxNSS.Items.Add("System.Globalization");
                comboboxNSS.Items.Add("System.IdentityModel.Claims");
                comboboxNSS.Items.Add("System.IO");
                comboboxNSS.Items.Add("System.IO.Compression");
                comboboxNSS.Items.Add("System.IO.IsolatedStorage");
                comboboxNSS.Items.Add("System.IO.Pipes");
                comboboxNSS.Items.Add("System.IO.Ports");
                comboboxNSS.Items.Add("System.Linq");
                comboboxNSS.Items.Add("System.Linq.Expressions");
                comboboxNSS.Items.Add("System.Reflection");
                comboboxNSS.Items.Add("System.Reflection.Emit");
                comboboxNSS.Items.Add("System.Resources");
                comboboxNSS.Items.Add("System.Runtime.Serialization");
                comboboxNSS.Items.Add("System.Runtime.Serialization.Json");
                comboboxNSS.Items.Add("System.Security");
                comboboxNSS.Items.Add("System.Security.AccessControl");
                comboboxNSS.Items.Add("System.Security.Cryptography");
                comboboxNSS.Items.Add("System.Security.Cryptography.X509Certificates");
                comboboxNSS.Items.Add("System.Security.Principal");
                comboboxNSS.Items.Add("System.ServiceProcess");
                comboboxNSS.Items.Add("System.Text");
                comboboxNSS.Items.Add("System.Text.RegularExpressions");
                comboboxNSS.Items.Add("System.Threading");
                comboboxNSS.Items.Add("System.Transactions");
            }
            else if ((string)comboboxMainNS.SelectedValue == "Data, XML and LINQ")
            {
                comboboxNSS.Items.Clear();
                comboboxNSS.Items.Add("System.Data");
                comboboxNSS.Items.Add("System.Data.Common");
                comboboxNSS.Items.Add("System.Data.Linq");
                comboboxNSS.Items.Add("System.Data.Linq.Mapping");
                comboboxNSS.Items.Add("System.Data.Odbc");
                comboboxNSS.Items.Add("System.Data.OleDb");
                comboboxNSS.Items.Add("System.Data.OracleClient");
                comboboxNSS.Items.Add("System.Data.SqlClient");
                comboboxNSS.Items.Add("System.Xml");
                comboboxNSS.Items.Add("System.Xml.Linq");
                comboboxNSS.Items.Add("System.Xml.Schema");
                comboboxNSS.Items.Add("System.Xml.Serialization");
                comboboxNSS.Items.Add("System.Xml.Xsl");
            }
            else if ((string)comboboxMainNS.SelectedValue == "WPF & Windows Forms")
            {
                comboboxNSS.Items.Clear();
                comboboxNSS.Items.Add("System.Windows");
                comboboxNSS.Items.Add("System.Windows.Controls");
                comboboxNSS.Items.Add("System.Windows.Controls.Primitives");
                comboboxNSS.Items.Add("System.Windows.Data");
                comboboxNSS.Items.Add("System.Windows.Documents");
                comboboxNSS.Items.Add("System.Windows.Documents.Serialization");
                comboboxNSS.Items.Add("System.Windows.Forms.Integration");
                comboboxNSS.Items.Add("System.Windows.Input");
                comboboxNSS.Items.Add("System.Windows.Interop");
                comboboxNSS.Items.Add("System.Windows.Markup");
                comboboxNSS.Items.Add("System.Windows.Media");
                comboboxNSS.Items.Add("System.Windows.Media.Animation");
                comboboxNSS.Items.Add("System.Windows.Media.Effects");
                comboboxNSS.Items.Add("System.Windows.Media.Imaging");
                comboboxNSS.Items.Add("System.Windows.Media.Media3D");
                comboboxNSS.Items.Add("System.Windows.Navigation");
                comboboxNSS.Items.Add("System.Windows.Shapes");
                comboboxNSS.Items.Add("System.Windows.Threading");
                comboboxNSS.Items.Add("System.Windows.Xps");
                comboboxNSS.Items.Add("System.Windows.Xps.Serialization");
                comboboxNSS.Items.Add("System.Drawing ");
                comboboxNSS.Items.Add("System.Drawing.Printing");
                comboboxNSS.Items.Add("System.Media");
                comboboxNSS.Items.Add("System.Windows.Forms");
            }
            else if ((string)comboboxMainNS.SelectedValue == "Microsoft")
            {
                comboboxNSS.Items.Clear();
                comboboxNSS.Items.Add("Microsoft");
                comboboxNSS.Items.Add("Microsoft.CSharp");
                comboboxNSS.Items.Add("Microsoft.CSharp.RuntimeBinder");
                comboboxNSS.Items.Add("Microsoft.Runtime");
                comboboxNSS.Items.Add("Microsoft.Runtime.Hosting");
                comboboxNSS.Items.Add("Microsoft.SqlServer");
                comboboxNSS.Items.Add("Microsoft.SqlServer.Server");
                comboboxNSS.Items.Add("Microsoft.Win32");
                comboboxNSS.Items.Add("Microsoft.Win32.SafeHandles");
            }
            comboboxNSS.SelectedIndex = 0;
        }

        private void buttonAddUsingDirective_Click(object sender, RoutedEventArgs e)
        {
            #region Controls

            // border 
            Border borderParam = new Border();
            borderParam.BorderThickness = new Thickness(1);
            borderParam.BorderBrush = (SolidColorBrush)Application.Current.Resources["BorderBrush2"];
            borderParam.Background = (SolidColorBrush)Application.Current.Resources["BackgroundBrush"];
            borderParam.Height = 25;
            borderParam.Margin = new Thickness(10, 10, 10, 0);

            // create a label holding the parameter information
            Label usingDirective = new Label();
            usingDirective.Padding = new Thickness(2);
            usingDirective.Foreground = (SolidColorBrush)Application.Current.Resources["DisabledBackgroundBrush"];
            usingDirective.Content = "using " + comboboxNSS.SelectedValue.ToString() + ";";

            // create a button to remove the parameter
            Button removeUsingDirective = new Button();
            removeUsingDirective.Click += removeUsingDirective_Click;

            // button attributes
            removeUsingDirective.OpacityMask = (DrawingBrush)Application.Current.Resources["RemoveParameterButtonBrush"];
            removeUsingDirective.Background = (SolidColorBrush)Application.Current.Resources["RedBrush"];
            removeUsingDirective.Width = 23;
            removeUsingDirective.Height = 23;
            removeUsingDirective.Margin = new Thickness(0, 0, 10, 0);
            removeUsingDirective.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            removeUsingDirective.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            removeUsingDirective.Style = (Style)Application.Current.Resources["AlphaButtonStyle"];

            #endregion

            // adding the label and the button to a grid
            System.Windows.Controls.Grid g = new System.Windows.Controls.Grid();
            g.Children.Add(usingDirective);
            g.Children.Add(removeUsingDirective);

            // add the grid as a child of the border and add the border to the parameter stackpanel.
            borderParam.Child = g;
            stackPanelOuter.Children.Insert(stackPanelOuter.Children.Count - 1, borderParam);

            this.Height += 35;
            this.Refresh();
        }

        private void removeUsingDirective_Click(object sender, RoutedEventArgs e)
        {
            // remove from children collection of the stackPanel
            Border parent = ((e.Source as Button).Parent as System.Windows.Controls.Grid).Parent as Border;

            stackPanelOuter.Children.Remove(parent);

            this.Height -= 35;
            this.Refresh();
        }
        public override string ToExecString()
        {
            string s = "";

            for (int i = 1; i <= stackPanelOuter.Children.Count - 2; i++)
                s += (((stackPanelOuter.Children[i] as Border).Child as Grid).Children[0] as Label).Content.ToString() + "\n";

            s += "\n";
            AppendToCodeBlock(s);

            return s;
        }

        public override void ToXml(XmlWriter x)
        {
            x.WriteStartElement("Using");

            for (int i = 1; i <= stackPanelOuter.Children.Count - 2; i++)
            {
                string usingDirective = (((stackPanelOuter.Children[i] as Border).Child as Grid).Children[0] as Label).Content.ToString();
                x.WriteStartElement("Directive");
                x.WriteAttributeString("String", usingDirective);
                x.WriteEndElement();
            }

            x.WriteEndElement();
        }

        public override void FromXml(XmlNode node)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++ )
            {
                RoutedEventArgs e = new RoutedEventArgs(Button.ClickEvent, buttonAddUsing);
                buttonAddUsing.RaiseEvent(e);

                XmlNode innerNode = node.ChildNodes[i];
                (((stackPanelOuter.Children[i + 1] as Border).Child as Grid).Children[0] as Label).Content = innerNode.Attributes["String"].Value;
            }
        }

        private void gridHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                gridHeader.ToolTip = Utilities.usingString;
            else
                gridHeader.ToolTip = "using block";
        }

        private void comboboxMainNS_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxMainNS.ToolTip = Utilities.usinngMains;
            else
                comboboxMainNS.ToolTip = "";
        }

        private void comboboxNSS_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Utilities.helpActive)
                comboboxNSS.ToolTip = Utilities.usinngnamespace;
            else
                comboboxNSS.ToolTip = "";
        }

    }
}
