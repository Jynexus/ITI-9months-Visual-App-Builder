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
using ResourceClasses;

namespace Grid
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ClassBlock : ResourceClasses.Block
    {
        public ClassBlock()
        {
            InitializeComponent();

            blockControl.MinWidth = 200;
            blockControl.MinHeight = 100;
            
            fillModifierComboBox();

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
        //
        // utility methods
        //
        public void fillModifierComboBox()
        {
            comboboxModifier.Items.Add("public");
            comboboxModifier.Items.Add("protected");
            comboboxModifier.Items.Add("private");

            comboboxModifier.Items.Add("public static");
            comboboxModifier.Items.Add("protected static");
            comboboxModifier.Items.Add("private static");
        }

        public override string ToExecString()
        {
            string s;

            s = comboboxModifier.SelectedItem + TextboxName.Text + "\n{\n";

            foreach (ResourceClasses.Block block in stackPanelBody.Children)
                s += block.ToExecString();

            s += "\n}";

            return s;
        }
    }

}
