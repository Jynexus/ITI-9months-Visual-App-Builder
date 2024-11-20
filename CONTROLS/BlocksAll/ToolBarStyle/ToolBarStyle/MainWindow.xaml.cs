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
using VisualApplicationBuilder.Block;
using VisualApplicationBuilder.ResourceClasses;

namespace ToolBarStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPressed;
        bool isDragging;
        Point startPoint;
        UIElement realDragSource;
        UIElement dummyDragSource = new UIElement();

        public MainWindow()
        {
            InitializeComponent();

            this.WindowStyle = System.Windows.WindowStyle.None;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(Button))
            {
                isPressed = true;
                startPoint = e.GetPosition(this);
            }
        }

        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Vector movement = e.GetPosition(this) - startPoint;

            if (isPressed && e.Source.GetType() == typeof(Button))
            {
                if (isDragging == false &&
                    (Math.Abs(movement.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(movement.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    isDragging = true;
                    realDragSource = e.Source as UIElement;
                    realDragSource.CaptureMouse();

                    string buttonName = ((Button)e.Source).Name;
                    BlockBase newBlock = new BlockBase();
                    switch (buttonName)
                    {
                        case "buttonUsing":
                            newBlock = new UsingBlock();
                            Utilities.blockType = typeof(UsingBlock);
                            break;

                        case "buttonNamespace":
                            newBlock = new NamespaceBlock();
                            Utilities.blockType = typeof(NamespaceBlock);
                            break;

                        case "buttonClass":
                            newBlock = new ClassBlock();
                            Utilities.blockType = typeof(ClassBlock);
                            break;

                        case "buttonVariable":
                            newBlock = new DataTypesBlock();
                            Utilities.blockType = typeof(DataTypesBlock);
                            break;

                        case "buttonCondition":
                            newBlock = new ifThenElseBlock();
                            Utilities.blockType = typeof(ifThenElseBlock);
                            break;

                        case "buttonLoop":
                            newBlock = new ForBlock();
                            Utilities.blockType = typeof(ForBlock);
                            break;
                    }

                    DataObject data = new DataObject(Utilities.blockType, newBlock);

                    DragDrop.DoDragDrop(realDragSource, data, DragDropEffects.Move);
                }
            }
        }

        private void stackPanelDropZone_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(UsingBlock)) && e.Source.GetType() == typeof(StackPanel))
                e.Effects = DragDropEffects.Move;
        }

        private void stackPanelDropZone_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(Utilities.blockType) && e.Source.GetType() == typeof(StackPanel))
            {
                BlockBase draggedData = (BlockBase)e.Data.GetData(Utilities.blockType);

                // if the Block is already instantiated, remove it from its old parent's tree
                Panel parentPanel = (Panel)draggedData.Parent;

                string x;
                if (parentPanel != null)
                    x = parentPanel.GetValue(NameProperty).ToString();
                
                if (parentPanel != null)
                    parentPanel.Children.Remove(draggedData);

                stackPanelDropZone.Children.Add(draggedData);
            }

            isPressed = false;
            isDragging = false;

            Mouse.Capture(null);
        }

        private void gridMain_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isPressed = false;
            isDragging = false;
            Mouse.Capture(null);
        }
    }
   
}