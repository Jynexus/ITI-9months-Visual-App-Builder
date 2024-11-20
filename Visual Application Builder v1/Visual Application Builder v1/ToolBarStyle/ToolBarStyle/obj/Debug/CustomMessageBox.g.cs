﻿#pragma checksum "..\..\CustomMessageBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1ECCFB8660C8330CB67311A123FD3BB2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BlocksAll {
    
    
    /// <summary>
    /// CustomMessageBox
    /// </summary>
    public partial class CustomMessageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderOuter;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelOuter;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridHeader;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelBlockName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse statusIndicator;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRemoveBlock;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelMessageHeader;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockMessageBody;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ToolBarStyle;component/custommessagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomMessageBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.borderOuter = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.stackPanelOuter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.gridHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.labelBlockName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.statusIndicator = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            this.buttonRemoveBlock = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\CustomMessageBox.xaml"
            this.buttonRemoveBlock.Click += new System.Windows.RoutedEventHandler(this.buttonRemoveBlock_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.labelMessageHeader = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.textBlockMessageBody = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 22 "..\..\CustomMessageBox.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonRemoveBlock_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

