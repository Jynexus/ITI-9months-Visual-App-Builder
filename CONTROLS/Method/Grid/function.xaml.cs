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
using System.Reflection;


namespace Grid
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class function : ResourceClasses.Block
    {
        Boolean Firstparameter = true;
        public function()
        {
            InitializeComponent();
            fillReturnType();
            fillModifier();
            blockControl.MinWidth = 200;
            blockControl.MinHeight = 100;

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
                ApplicationVariables.isPressed = true;
                ApplicationVariables.startPoint = e.GetPosition(e.Source as UIElement);
            }
        }

        private void sp_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Vector movement = e.GetPosition(e.Source as UIElement) - ApplicationVariables.startPoint;

            if (ApplicationVariables.isPressed && e.Source.GetType() == typeof(ResourceClasses.Block))
            {
                if (ApplicationVariables.isDragging == false &&
                    (Math.Abs(movement.X) > SystemParameters.MinimumHorizontalDragDistance ||
                     Math.Abs(movement.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    ApplicationVariables.isDragging = true;
                    ApplicationVariables.realDragSource = e.Source as ResourceClasses.Block;
                    Mouse.Capture(ApplicationVariables.realDragSource);
                    DataObject data = new DataObject(typeof(ResourceClasses.Block), e.Source);

                    DragDrop.DoDragDrop(ApplicationVariables.dummyDragSource, data, DragDropEffects.Move);
                }
            }
        }

        public void fillReturnType()
        {
            object s = new object();
            Assembly thePrimitiveAssembly = Assembly.Load("mscorlib");
            Type[] thePrimitiveAssembly_Types = thePrimitiveAssembly.GetTypes();
            foreach (var item in thePrimitiveAssembly_Types)
            {
                if (item.IsPrimitive == true)
                {
                    comboboxReturnType.Items.Add(item);
                    comboboxParameterDataType.Items.Add(item);
                }
            }
            comboboxReturnType.Items.Add("Other");
            comboboxParameterDataType.Items.Add("Other");
        }
        public void fillModifier()
        {
            comboboxModifier.Items.Add("public");
            comboboxModifier.Items.Add("protected");
            comboboxModifier.Items.Add("private");
        }

        private void comboboxReturnType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxReturnType.SelectedItem.ToString() == "Other")
                Textboxfunctionname.Text = "return_type function_name";
            else if (comboboxReturnType.SelectedItem.ToString() != "Other" && IsLoaded)
                Textboxfunctionname.Text = "function_name";
        }

        private void comboboxParameterDataType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboboxParameterDataType.SelectedItem.ToString() == "Other")
                TextboxParameterName.Text = "parameter_type parameter_name";
            else if (comboboxParameterDataType.SelectedItem.ToString() != "Other" && IsLoaded)
                TextboxParameterName.Text = "parameter_name";

        }

        private void buttonAddParameter_Click(object sender, RoutedEventArgs e)
        {
            #region Controls
            Border borderParam = new Border();
            borderParam.BorderThickness = new Thickness(1);
            borderParam.CornerRadius = new CornerRadius(3);
            borderParam.BorderBrush = new SolidColorBrush(Colors.LightSteelBlue);
            borderParam.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
            borderParam.Height = 30;
            borderParam.Margin = new Thickness(10, 10, 10, 0);

            Label param = new Label();
            param.Foreground = new SolidColorBrush(Colors.LightSteelBlue);
            param.Content = comboboxParameterDataType.SelectedItem.ToString() + " " + TextboxParameterName.Text;

            Button removeParameter = new Button();
            removeParameter.Click += removeParameter_Click;

            DrawingBrush dBrush = new DrawingBrush();
            DrawingGroup dGroup = new DrawingGroup();
            Pen p = new Pen(new SolidColorBrush(Colors.Black), 4);

            GeometryDrawing gDrawingEllipse = new GeometryDrawing();
            gDrawingEllipse.Geometry = new EllipseGeometry(new Point(0, 0), 15, 15);
            gDrawingEllipse.Pen = p;

            GeometryDrawing gDrawingMinus = new GeometryDrawing();

            PathGeometry pGeometryMinus = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(-7, 0);
            pFigure.Segments.Add(new LineSegment(new Point(7, 0), true));
            pFigure.IsClosed = false;
            pGeometryMinus.Figures.Add(pFigure);

            gDrawingMinus.Geometry = pGeometryMinus;
            gDrawingMinus.Pen = p;

            dGroup.Children.Add(gDrawingEllipse);
            dGroup.Children.Add(gDrawingMinus);

            dBrush.Drawing = dGroup;

            removeParameter.OpacityMask = dBrush;
            removeParameter.Background = new SolidColorBrush(Colors.Firebrick);
            removeParameter.Width = 30;
            removeParameter.Height = 30;
            removeParameter.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            removeParameter.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;

            ScaleTransform sT = new ScaleTransform(.7, .7);
            TranslateTransform tT = new TranslateTransform(.1, .1);
            TransformGroup tG = new TransformGroup();

            tG.Children.Add(sT);
            tG.Children.Add(tT);

            removeParameter.OpacityMask.RelativeTransform = tG;

            #endregion

            System.Windows.Controls.Grid g = new System.Windows.Controls.Grid();
            g.Children.Add(param);
            g.Children.Add(removeParameter);

            borderParam.Child = g;
            stackPanelParameters.Children.Insert(2, borderParam);
        }

        private void removeParameter_Click(object sender, RoutedEventArgs e)
        {
            // remove from children collection of the stackPanel
            Border parent = ((e.Source as Button).Parent as System.Windows.Controls.Grid).Parent as Border;

            stackPanelParameters.Children.Remove(parent);
            // resize the stackPanel!!!
        }

        public override string ToExecString()
        {
            string s;
            if (stackPanelParameters.Children.Count > 3)
            {
                s = comboboxModifier.SelectedItem.ToString() + " " + comboboxReturnType.SelectedItem.ToString() + " " + Textboxfunctionname.Text + "("; ;
                for (int i = stackPanelParameters.Children.Count - 2; i >= 2; i--)
                {
                    if (Firstparameter)
                        Firstparameter = false;
                    else
                        s += ",";
                    Border br = (Border)stackPanelParameters.Children[i];
                    System.Windows.Controls.Grid gr = (System.Windows.Controls.Grid)br.Child;
                    s += (((Label)gr.Children[0]).Content.ToString());
                }
                s += ")" + @"
               {";
                if (gridMethodBody.Children.Count > 2)
                {
                    var children = gridMethodBody.Children;
                    foreach (var child in children)
                    {
                        s += child.GetType().GetMethod("ToExecString").Invoke(child, null);
                    }
                }
                else
                { s += " "; }
                s += @"
              }";
                
            }
            else 
                s="Kindly add function parameter ";
            return s;
        }
    }
}
