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
    public partial class StatementBlock : ResourceClasses.BlockBase
    {
        public StatementBlock()
        {
            InitializeComponent();

            buttonRemoveBlock.PreviewMouseLeftButtonDown += buttonRemoveBlock_PreviewMouseLeftButtonDown;

            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";
        }

        public override string ToExecString()
        {
            string s = textBoxStatement.Text;

            if (s[s.Length - 1] != ';')
                s += ";";

            s = Utilities.indent + s + "\n";

            return s;
        }
    }

}
