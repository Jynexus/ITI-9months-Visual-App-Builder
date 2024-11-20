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
using System.Reflection;
using VisualApplicationBuilder.ResourceClasses;
using System.Windows.Media.Animation;


namespace VisualApplicationBuilder.Block
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SwitchBlock : BlockBase
    {
        public Boolean varStatus = false;
        public Boolean caseStatus = false;
        public SwitchBlock()
        {
            InitializeComponent();
        }

        private void buttonAddCase_Click(object sender, RoutedEventArgs e)
        {   
            Grid gridCase = new Grid();
            gridCase.Margin = new Thickness(10, 10, 10, 0);
            gridCase.Height = 225;

            Grid caseStatementGrid = new Grid();
            caseStatementGrid.Height = 25;
            caseStatementGrid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            
            #region case header
            // case block header - label
            Border caseStatementBorder1 = new Border();
            caseStatementBorder1.Width = 90;
            caseStatementBorder1.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            caseStatementBorder1.BorderThickness = new Thickness(1);
            caseStatementBorder1.BorderBrush = (SolidColorBrush)this.Resources["BlueBrush"];

            TextBox caseStatementLabel = new TextBox();
            caseStatementLabel.Text = "case";
            caseStatementLabel.IsReadOnly = true;
            caseStatementLabel.BorderBrush = null;
            caseStatementLabel.Background = null;
            caseStatementLabel.Foreground = (SolidColorBrush)this.Resources["BorderBrush"];
            caseStatementBorder1.Child = caseStatementLabel;


            // case block header - textbox
            Border caseStatementBorder2 = new Border();
            caseStatementBorder2.Margin = new Thickness(90, 0, 0, 0);
            caseStatementBorder2.BorderThickness = new Thickness(0, 1, 1, 1);
            caseStatementBorder2.BorderBrush = (SolidColorBrush)this.Resources["BlueBrush"];
            caseStatementBorder2.Background = (SolidColorBrush)this.Resources["BorderBrush"];

            TextBox caseStatementTextBox = new TextBox();
            caseStatementTextBox.Margin = new Thickness(0, 0, 40, 0);
            caseStatementTextBox.BorderBrush = null;
            caseStatementTextBox.Background = null;
            caseStatementBorder2.Child = caseStatementTextBox;

            Button buttonRemoveCase = new Button();
            buttonRemoveCase.Click += buttonRemoveCase_Click;
            buttonRemoveCase.OpacityMask = (DrawingBrush)this.Resources["RemoveParameterButtonBrush"];
            buttonRemoveCase.Background = (SolidColorBrush)this.Resources["RedBrush"];
            buttonRemoveCase.Width = 23;
            buttonRemoveCase.Height = 23;
            buttonRemoveCase.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            buttonRemoveCase.Margin = new Thickness(0, 0, 10, 0);
            buttonRemoveCase.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            buttonRemoveCase.Style = (Style)this.Resources["AlphaButtonStyle"];
            
            caseStatementGrid.Children.Add(caseStatementBorder1);
            caseStatementGrid.Children.Add(caseStatementBorder2);
            caseStatementGrid.Children.Add(buttonRemoveCase);

            #endregion

            #region case stack panel
            
            // border
            Border caseBodyBorder = new Border();
            caseBodyBorder.BorderThickness = new Thickness(1);
            caseBodyBorder.BorderBrush = (SolidColorBrush)this.Resources["BlueBrush"];
            caseBodyBorder.Margin = new Thickness(0, 24, 0, 0);

            StackPanel caseBodyStackPanel = new StackPanel();
            caseBodyStackPanel.Background = (SolidColorBrush)this.Resources["BackgroundBrush"];

            caseBodyBorder.Child = caseBodyStackPanel;

            gridCase.Children.Add(caseStatementGrid);
            gridCase.Children.Add(caseBodyBorder);

            #endregion
            // finally, add the entire case grid to the control. sheww! That was a long journey!
            stackPanelOuter.Children.Insert(stackPanelOuter.Children.Count - 1, gridCase);

            DoubleAnimation resizeBlockAnimation = new DoubleAnimation(this.Height, this.Height + 235, new Duration(TimeSpan.FromSeconds(.1)));
            this.BeginAnimation(HeightProperty, resizeBlockAnimation);
        }

        private void buttonRemoveCase_Click(object sender, RoutedEventArgs e)
        {
            Grid gridCase = ((e.Source as Button).Parent as Grid).Parent as Grid;
            double height = gridCase.Height + 10; // the DC shift to account for the margin. 

            stackPanelOuter.Children.Remove(gridCase);

            DoubleAnimation resizeBlockAnimation = new DoubleAnimation(this.Height, this.Height - height, new Duration(TimeSpan.FromSeconds(.1)));
            this.BeginAnimation(HeightProperty, resizeBlockAnimation);
        }

        public override string ToExecString()
        {
            string s = "";
            return s;
        }
    }
}
