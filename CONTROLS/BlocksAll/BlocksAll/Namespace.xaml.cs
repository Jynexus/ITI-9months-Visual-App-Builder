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
            buttonRemoveBlock.PreviewMouseLeftButtonDown += buttonRemoveBlock_PreviewMouseLeftButtonDown;

            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";
        }

        // old school parameter assignment.
        // should've been implemented with TemplateBinding or something like that. This is WPF!!
        private void blockControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (blockControl.Height >= 100)
            //    connectionBot.Margin = new Thickness(10, blockControl.Height - 17, 0, 0);
        }

        public override string ToExecString()
        {
            string s = Utilities.indent + "namespace " + textBoxName.Text + "\n" + Utilities.indent + "{";

            Utilities.indent += "\t";
            foreach (ResourceClasses.BlockBase block in stackPanelBody.Children)
                s += block.ToExecString();

            // remove the tab
            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 2);

            s += "\n" + Utilities.indent + "}\n";

            return s;
        }
    }

}
