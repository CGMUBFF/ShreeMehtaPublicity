﻿#pragma checksum "..\..\..\VIEW\ViewSite.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AA8CC38C68EE05F75AAE75A41041EE6289E79587"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using ShreeMehtaPublicity.Utility;
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
using System.Windows.Interactivity;
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


namespace ShreeMehtaPublicity.VIEW {
    
    
    /// <summary>
    /// ViewSite
    /// </summary>
    public partial class ViewSite : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ShreeMehtaPublicity.VIEW.ViewSite ViewSiteWindow;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ListBorder;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDate;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDate;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reset;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\VIEW\ViewSite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
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
            System.Uri resourceLocater = new System.Uri("/ShreeMehtaPublicity;component/view/viewsite.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VIEW\ViewSite.xaml"
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
            this.ViewSiteWindow = ((ShreeMehtaPublicity.VIEW.ViewSite)(target));
            return;
            case 2:
            this.ListBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.StartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.EndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.Search = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Reset = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\VIEW\ViewSite.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

