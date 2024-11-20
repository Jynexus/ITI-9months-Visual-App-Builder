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
    public partial class ClassBlock : ResourceClasses.BlockBase
    {
        public ClassBlock()
        {
            InitializeComponent();

            // wiring events to their handlers
            buttonRemoveBlock.PreviewMouseLeftButtonDown += buttonRemoveBlock_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonDown += Block_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += Block_PreviewMouseLeftButtonUp;
            this.PreviewMouseMove += Block_PreviewMouseMove;
            this.SizeChanged += blockControl_SizeChanged;

            stackPanelBody.DragEnter += stackPanel_DragEnter;
            stackPanelBody.Drop += stackPanel_Drop;

            fillModifierComboBox();

            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";
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

            s = Utilities.indent + comboboxModifier.SelectedItem + TextboxName.Text + "\n" + Utilities.indent + "{\n";

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
