﻿#pragma checksum "..\..\VariableBlock.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "114DF11955B937F9D56EC5236532619D"
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
using VisualApplicationBuilder.ResourceClasses;


namespace VisualApplicationBuilder.Block {
    
    
    /// <summary>
    /// VariableBlock
    /// </summary>
    public partial class VariableBlock : VisualApplicationBuilder.ResourceClasses.BlockBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderOuter;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelOuter;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridHeader;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelBlockName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse statusIndicator;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonHighlight;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRemoveBlock;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxComplexType;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxComplexType;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border gridIf;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\VariableBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxIdentifier;
        
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
            System.Uri resourceLocater = new System.Uri("/BlocksAll;component/variableblock.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VariableBlock.xaml"
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
            
            #line 8 "..\..\VariableBlock.xaml"
            ((VisualApplicationBuilder.Block.VariableBlock)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.blockControl_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.borderOuter = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.stackPanelOuter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.gridHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.labelBlockName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.statusIndicator = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 7:
            this.buttonHighlight = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.buttonRemoveBlock = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.checkboxComplexType = ((System.Windows.Controls.CheckBox)(target));
            
            #line 28 "..\..\VariableBlock.xaml"
            this.checkboxComplexType.Click += new System.Windows.RoutedEventHandler(this.checkboxComplexType_Check);
            
            #line default
            #line hidden
            return;
            case 10:
            this.comboboxComplexType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.gridIf = ((System.Windows.Controls.Border)(target));
            return;
            case 12:
            this.textBoxIdentifier = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

