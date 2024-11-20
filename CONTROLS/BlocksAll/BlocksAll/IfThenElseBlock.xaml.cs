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
    public partial class ifThenElseBlock : ResourceClasses.BlockBase
    {
        public ifThenElseBlock()
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
        //
        // moving a block about
        //
        Point position;
        private void blockControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void blockControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point newPosition = e.GetPosition(this.Parent as UIElement);
                this.Margin = new Thickness(newPosition.X - position.X, newPosition.Y - position.Y, 0, 0);
            }
        }
        //
        // drag/drop
        //
        private void sp_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(Label)) // if the clicked control wasn't the stack panel itself!
            {
                Utilities.isPressed = true;
                Utilities.startPoint = e.GetPosition(e.Source as UIElement);
            }
        }

        private void sp_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Vector movement = e.GetPosition(e.Source as UIElement) - Utilities.startPoint;

            if (Utilities.isPressed && e.Source.GetType() == typeof(ResourceClasses.BlockBase))
            {
                if (Utilities.isDragging == false &&
                    (Math.Abs(movement.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(movement.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    Utilities.isDragging = true;
                    Utilities.realDragSource = e.Source as ResourceClasses.BlockBase;
                    Mouse.Capture(Utilities.realDragSource);
                    DataObject data = new DataObject(typeof(ResourceClasses.BlockBase), e.Source);

                    DragDrop.DoDragDrop(Utilities.dummyDragSource, data, DragDropEffects.Move);
                }
            }
        }
        public override string ToExecString()
        {
            string s = Utilities.indent + "if (" + textBoxCondition.Text + ")\n" + Utilities.indent + "{\n";
            
            var children = stackPanelThen.Children;

            Utilities.indent += "\t";
            foreach (ResourceClasses.BlockBase child in children)
                s += child.ToExecString();

            Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 2);

            if (stackPanelElse.Children.Count > 0)
            {
                s += Utilities.indent + "\n}\n" + Utilities.indent + "else\n" + Utilities.indent + "\n{\n";

                children = stackPanelElse.Children;

                Utilities.indent += "\t";
                foreach (ResourceClasses.BlockBase child in children)
                    s += child.ToExecString();

                Utilities.indent = Utilities.indent.Remove(Utilities.indent.Length - 2);

                s += "\n" + Utilities.indent + "}\n";
            }

            return s;
        }
    }

}
