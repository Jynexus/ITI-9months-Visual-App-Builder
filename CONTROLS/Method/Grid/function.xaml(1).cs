﻿using System;
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
        string FunctionParameterString;
        string FunctionParameterTypeString;
        string FunctionRetunrnTypeString;
        string FunctionNameString;
        string FunctionModifierString;
        string FunctionFinalString;
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
            {
                textboxReturnComplexType.IsEnabled = true;
            }

            else
            {
                if (textboxReturnComplexType.IsEnabled)
                { 
                    textboxReturnComplexType.IsEnabled = false; 
                }
            }
        }

        private void comboboxParameterDataType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxParameterDataType.SelectedItem.ToString() == "Other")
            {
                textboxParameterComplexType.IsEnabled = true;
            }
            else
            {
                if (textboxParameterComplexType.IsEnabled)
                {
                    textboxParameterComplexType.IsEnabled = false;
                }
            }
        }

        private void buttonAddParameter_Click(object sender, RoutedEventArgs e)
        {
            if (Firstparameter)
            {
                Firstparameter = false;
            }
            else
            {
                FunctionParameterString += ",";
            }
            if (comboboxReturnType.SelectedItem.ToString() == "Other")
            {
                /*comboboxReturnType.SelectedItem = "";
                textboxReturnComplexType.IsEnabled = true;*/
                FunctionRetunrnTypeString = textboxReturnComplexType.Text;
            }
            else { FunctionRetunrnTypeString = comboboxReturnType.SelectedItem.ToString(); }
            if (comboboxParameterDataType.SelectedItem.ToString() == "Other")
            {
                /*comboboxParameterDataType.SelectedItem = "";
                textboxParameterComplexType.IsEnabled = true;*/
                FunctionParameterTypeString = textboxParameterComplexType.Text;
            }
            else { FunctionParameterTypeString = comboboxParameterDataType.SelectedItem.ToString(); }

            FunctionParameterString += FunctionParameterTypeString + " " + TextboxParameterName.Text;
            TextboxParameterName.Clear();
            finalStringbuilding();

        }
        public void finalStringbuilding()
        {
            FunctionFinalString = comboboxModifier.SelectedItem.ToString() + " " + FunctionRetunrnTypeString + " " + Textboxfunctionname.Text + "(" + FunctionParameterString + ")" + "{}";
            MessageBox.Show(FunctionFinalString);

        }
       /* public override string ToExecString()
        {
            string s = "if (" + textBoxCondition.Text + "){";
            var children = stackPanelThen.Children;

            foreach (ResourceClasses.Block child in children)
                s += child.ToExecString();

            if (stackPanelElse.Children.Count > 0)
            {
                s += "} else {";

                children = stackPanelElse.Children;
                foreach (ResourceClasses.Block child in children)
                    s += child.ToExecString();

                s += "}";
            }

            return s;
        }*/

    }

}