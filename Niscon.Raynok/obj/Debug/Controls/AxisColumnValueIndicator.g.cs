﻿#pragma checksum "..\..\..\Controls\AxisColumnValueIndicator.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B2266DF639BFCF5AA1DB480692A3D728"
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
using Niscon.Raynok.Converters;
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
    /// AxisColumnValueIndicator
    /// </summary>
    public partial class AxisColumnValueIndicator : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InnerGrid;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border TargetValueTop;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border StartValueTop;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border TargetValueBottom;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border StartValueBottom;
        
        #line default
        #line hidden
        
        
        #line 317 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border CurrentValue;
        
        #line default
        #line hidden
        
        
        #line 375 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LockImage;
        
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
            System.Uri resourceLocater = new System.Uri("/Niscon.Raynok;component/controls/axiscolumnvalueindicator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
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
            this.InnerGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TargetValueTop = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.StartValueTop = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.TargetValueBottom = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.StartValueBottom = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.CurrentValue = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.LockImage = ((System.Windows.Controls.Grid)(target));
            
            #line 375 "..\..\..\Controls\AxisColumnValueIndicator.xaml"
            this.LockImage.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.LockImage_OnPreviewMouseUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

