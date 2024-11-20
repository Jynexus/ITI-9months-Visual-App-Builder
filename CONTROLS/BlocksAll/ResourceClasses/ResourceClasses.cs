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
using System.Windows.Threading;

namespace VisualApplicationBuilder.ResourceClasses
{
    public class BlockBase : UserControl
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
        //
        // Event handlers
        //
        // Remove block button
        protected void buttonRemoveBlock_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        // Drag-Drop
        protected void Block_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() != typeof(StackPanel))
            {
                Utilities.isPressed = true;
                Utilities.startPoint = e.GetPosition(this);
            }
        }
        protected void Block_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Utilities.isPressed = false;
            Utilities.isDragging = false;
            Mouse.Capture(null);
        }
        protected void Block_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Vector movement = e.GetPosition(this) - Utilities.startPoint;

            if (Utilities.isPressed)
            {
                if (Utilities.isDragging == false &&
                    (Math.Abs(movement.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(movement.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    Utilities.isDragging = true;
                    Utilities.realDragSource = e.Source as UIElement;
                    Mouse.Capture(Utilities.realDragSource);

                    DataObject dataBlock = new DataObject(e.Source.GetType(), e.Source);
                    Utilities.blockType = e.Source.GetType();
                    DragDrop.DoDragDrop(Utilities.realDragSource, dataBlock, DragDropEffects.Copy);
                }
            }
        }
        protected void stackPanel_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Source.GetType() == typeof(StackPanel))
                e.Effects = DragDropEffects.Move;
        }
        protected void stackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Source.GetType() == typeof(StackPanel))
            {
                StackPanel dropSource = e.Source as StackPanel;
                
                // dragged block
                BlockBase draggedData = (BlockBase)e.Data.GetData(Utilities.blockType);
                draggedData.Margin = new Thickness(10, 10, 0, 0);

                // if the Block is already instantiated, remove it from its old parent's tree
                Panel parentPanel = (Panel)draggedData.Parent;
                if (parentPanel != null)
                    parentPanel.Children.Remove(draggedData);
                
                // insert the dragged block into the tree of its new parent
                int index = dropSource.Children.Count;
                dropSource.Children.Insert(index, draggedData);
                BlockBase lastChild = dropSource.Children[index] as BlockBase;

                this.Refresh(); // really necessary call!!!!
                
                // calculate the new height of the parent block
                double height = lastChild.ActualHeight + lastChild.TranslatePoint(new Point(0, 0), dropSource).Y;
                this.Refresh(); // necessary call, trust me!

                double oldHeight = ((FrameworkElement)((FrameworkElement)((FrameworkElement)lastChild.Parent).Parent).Parent).Height;

                ((FrameworkElement)((FrameworkElement)dropSource.Parent).Parent).Height = height + 50;
                this.Refresh(); // still necessary.
                
                this.Height += ((height + 50) - oldHeight);
                this.Refresh(); // you guessed it! necessary, it is.

                if (Utilities.maxBlockWidth != 0)
                {
                    this.Width = Utilities.maxBlockWidth;
                }
                else
                {
                    double width = 0;
                    foreach (BlockBase block in dropSource.Children)
                    {
                        if (block.ActualWidth > width)
                            width = block.ActualWidth;
                    }
                    this.Width = width + 45;
                }
            }
            Utilities.isPressed = false;
            Utilities.isDragging = false;
            Mouse.Capture(null);
        }

        // resizing code
        protected void blockControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            BlockBase child = (BlockBase)sender;

            if (child.Parent.GetType() == typeof(StackPanel) && ((StackPanel)child.Parent).Parent.GetType() != typeof(ScrollViewer))
            {
                this.Refresh();

                double height = child.ActualHeight + child.TranslatePoint(new Point(0, 0), (StackPanel)child.Parent).Y;
                this.Refresh();

                double oldheight = ((FrameworkElement)((FrameworkElement)((FrameworkElement)child.Parent).Parent).Parent).Height;
                ((FrameworkElement)((FrameworkElement)((FrameworkElement)child.Parent).Parent).Parent).Height = height + 50;

                Utilities.grandParent = child.Parent;
                while (Utilities.grandParent.GetType().BaseType != typeof(BlockBase))
                {
                    Utilities.grandParent = VisualTreeHelper.GetParent((DependencyObject)Utilities.grandParent);
                }

                BlockBase theGrandControl = (BlockBase)Utilities.grandParent;
                this.Refresh();

                theGrandControl.Height += ((height + 50) - oldheight);
                this.Refresh();

                double width = 0;
                foreach (BlockBase block in ((StackPanel)child.Parent).Children)
                {
                    if (block.ActualWidth > width)
                        width = block.ActualWidth;
                }

                theGrandControl.Width = width + 45;
            }
        }
    }

    // application variables
    public static class Utilities
    {
        public static bool isPressed;
        public static bool isDragging;
        public static Point startPoint;
        public static UIElement realDragSource;
        public static UIElement dummyDragSource = new UIElement();

        public static Type blockType;
        public static string blockTypeString;

        public static string indent = "";

        public static object grandParent;
        public static double maxBlockWidth = 0;

        private static Action EmptyDelegate = delegate() { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}