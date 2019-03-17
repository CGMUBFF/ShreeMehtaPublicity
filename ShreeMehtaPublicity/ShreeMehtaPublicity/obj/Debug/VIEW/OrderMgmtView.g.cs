﻿#pragma checksum "..\..\..\VIEW\OrderMgmtView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D7E0DD25EB866620BFEB943BDB062556274DE7E"
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
    /// OrderMgmtView
    /// </summary>
    public partial class OrderMgmtView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ShreeMehtaPublicity.VIEW.OrderMgmtView OrderMgmtWindow;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ListBorder;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SiteList;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClientList;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Amount;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusComboBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDate;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDate;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reset;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Place;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\VIEW\OrderMgmtView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OrderList;
        
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
            System.Uri resourceLocater = new System.Uri("/ShreeMehtaPublicity;component/view/ordermgmtview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VIEW\OrderMgmtView.xaml"
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
            this.OrderMgmtWindow = ((ShreeMehtaPublicity.VIEW.OrderMgmtView)(target));
            return;
            case 2:
            this.ListBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.SiteList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ClientList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Amount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.StatusComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.StartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.EndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.Search = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.Reset = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.Place = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\VIEW\OrderMgmtView.xaml"
            this.Place.Click += new System.Windows.RoutedEventHandler(this.Place_Order);
            
            #line default
            #line hidden
            return;
            case 12:
            this.OrderList = ((System.Windows.Controls.ListView)(target));
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
            case 13:
            
            #line 119 "..\..\..\VIEW\OrderMgmtView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Mdfy_Order);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 128 "..\..\..\VIEW\OrderMgmtView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cncl_Order);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 137 "..\..\..\VIEW\OrderMgmtView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.View_Order);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

