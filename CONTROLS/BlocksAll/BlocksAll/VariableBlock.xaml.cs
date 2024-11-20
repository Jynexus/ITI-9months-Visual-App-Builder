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

namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DataTypesBlock : ResourceClasses.BlockBase
    {
        public DataTypesBlock()
        {
            InitializeComponent();
            buttonRemoveBlock.PreviewMouseLeftButtonDown += buttonRemoveBlock_PreviewMouseLeftButtonDown;

            Assembly thePrimitiveAssembly = Assembly.Load("mscorlib");
            Type[] thePrimitiveAssembly_Types = thePrimitiveAssembly.GetTypes();

            comboboxComplexType.Items.Clear();
            comboboxComplexType.Items.Add("Primitive type");

            foreach (var item in thePrimitiveAssembly_Types)
            {
                if (item.IsPrimitive)
                    comboboxComplexType.Items.Add(item);
            }

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
        //
        // Control-specific events
        //
        private void textboxIdentifier_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxIdentifier.Clear();
        }
        private void checkboxComplexType_Check(object sender, RoutedEventArgs e)
        {
            if (checkboxComplexType.IsChecked == true)
                comboboxComplexType.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string st = this.ToExecString();
            MessageBox.Show(st);
        }


        public override string ToExecString()
        {
            if (checkboxComplexType.IsChecked == true)
                return Utilities.indent + textBoxIdentifier.Text + "\n";

            else
                return Utilities.indent + comboboxComplexType.SelectedItem + " " + textBoxIdentifier.Text + "\n";
        }

    }
}
