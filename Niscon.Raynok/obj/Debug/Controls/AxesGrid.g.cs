﻿#pragma checksum "..\..\..\Controls\AxesGrid.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D1FDAE51CB50F8157C368A10CE8689D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Niscon.Raynok.Controls;
using Niscon.Raynok.Models;
using Niscon.Raynok.Models.Mock;
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


namespace Niscon.Raynok.Controls {
    
    
    /// <summary>
    /// AxesGrid
    /// </summary>
    public partial class AxesGrid : Niscon.Raynok.Controls.AxesDisplayControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\..\Controls\AxesGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CueAxesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\Controls\AxesGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Niscon.Raynok.Controls.LockPanel LockPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/Niscon.Raynok;component/controls/axesgrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\AxesGrid.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.CueAxesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.LockPanel = ((Niscon.Raynok.Controls.LockPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 19 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Image)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnPreviewMouseUp);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 66 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Label)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.CurrentValue_OnPreviewMouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Label)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnPreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 94 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Label)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TargetValue_OnPreviewMouseDoubleClick);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 123 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Label)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Velocity_OnPreviewMouseDoubleClick);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 147 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Label)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Acceleration_OnPreviewMouseDoubleClick);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 168 "..\..\..\Controls\AxesGrid.xaml"
            ((System.Windows.Controls.Label)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Deceleration_OnPreviewMouseDoubleClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

