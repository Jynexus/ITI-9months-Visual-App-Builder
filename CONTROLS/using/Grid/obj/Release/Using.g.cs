﻿#pragma checksum "..\..\Using.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0A20A38EB6C4928A7DE105DD8C48C077"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Grid;
using ResourceClasses;
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


namespace Grid {
    
    
    /// <summary>
    /// UsingBlock
    /// </summary>
    public partial class UsingBlock : ResourceClasses.BlockBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Grid.UsingBlock blockControl;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderOuter;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelOuter;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelBlockName;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse statusIndicator;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRemoveBlock;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelSeparator;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxMainNS;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\Using.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxNSS;
        
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
            System.Uri resourceLocater = new System.Uri("/Grid;component/using.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Using.xaml"
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
            this.blockControl = ((Grid.UsingBlock)(target));
            return;
            case 2:
            this.borderOuter = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.stackPanelOuter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.labelBlockName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.statusIndicator = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            this.buttonRemoveBlock = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.labelSeparator = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.comboboxMainNS = ((System.Windows.Controls.ComboBox)(target));
            
            #line 231 "..\..\Using.xaml"
            this.comboboxMainNS.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboboxMainNS_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.comboboxNSS = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

