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

namespace Grid
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class tempBlock : Block
    {
        public tempBlock()
        {
            InitializeComponent();
            blockControl.Height = 300;
            blockControl.Width = 300;

            blockControl.MinWidth = 200;
            blockControl.MinHeight = 100;

            statusIndicator.Status = false;
            string conditionExists = "invalid";
            string thenExists = "valid";
            statusIndicator.ToolTip = "Condition expression: " + conditionExists + "\n Then statement: " + thenExists;

            statusIndicator.ToolTip = "One or more of inner blocks are invalid";

            connectionStatusTop.IsConnected = true;
            connectionStatusBot.IsConnected = false;
        }

        // old school parameter assignment.
        // should've been implemented with TemplateBinding.
        private void blockControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (blockControl.Width >= 200)
            {
                borderOuter.Width = blockControl.Width;
                gridOuter.Width = blockControl.Width - 4;
                connectionStatusTop.Width = blockControl.Width - 24;
                connectionStatusBot.Width = blockControl.Width - 24;
                labelSeparator.Width = blockControl.Width - 24;
            }
            
            if (blockControl.Height >= 100)
            {
                gridOuter.Height = blockControl.Height - 4;
                connectionStatusBot.Margin = new Thickness(10, blockControl.Height - 17, 0, 0);
                borderOuter.Height = blockControl.Height;
            }

        }

        // moving a block about
        Point position;
        private void blockControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            position = e.GetPosition(this);
        }
        private void blockControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point newPosition = e.GetPosition(this.Parent as UIElement);
                this.Margin = new Thickness(newPosition.X - position.X, newPosition.Y - position.Y, 0, 0);
            }
        }

    }

    public class Block : UserControl
    {
        public virtual string ToExecString()
        {
            return "{}";
        }

        // report current status
        public virtual bool currentStatus()
        {
            return false;
        }

        // maybe used - for multiple selections
        public bool IsSelected { get; set; }
        public int BlockId { get; set; }
    }
}
