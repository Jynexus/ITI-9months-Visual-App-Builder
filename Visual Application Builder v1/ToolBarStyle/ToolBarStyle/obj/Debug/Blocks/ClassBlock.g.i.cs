﻿#pragma checksum "..\..\..\Blocks\ClassBlock.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DA133F09CDF678D75E3280D90E3C7D9F"
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
    /// ClassBlock
    /// </summary>
    public partial class ClassBlock : VisualApplicationBuilder.ResourceClasses.BlockBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelOuter;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridHeader;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelBlockName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse statusIndicator;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonHighlight;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRemoveBlock;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxModifier;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridBody;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Blocks\ClassBlock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelBody;
        
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
            System.Uri resourceLocater = new System.Uri("/ToolBarStyle;component/blocks/classblock.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Blocks\ClassBlock.xaml"
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
            this.stackPanelOuter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.gridHeader = ((System.Windows.Controls.Grid)(target));
            
            #line 16 "..\..\..\Blocks\ClassBlock.xaml"
            this.gridHeader.MouseEnter += new System.Windows.Input.MouseEventHandler(this.gridHeader_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.labelBlockName = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.statusIndicator = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 5:
            this.buttonHighlight = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.buttonRemoveBlock = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.comboboxModifier = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\Blocks\ClassBlock.xaml"
            this.comboboxModifier.MouseEnter += new System.Windows.Input.MouseEventHandler(this.comboboxModifier_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\Blocks\ClassBlock.xaml"
            this.textBoxName.MouseEnter += new System.Windows.Input.MouseEventHandler(this.textBoxName_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 9:
            this.gridBody = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.stackPanelBody = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

