#pragma checksum "..\..\..\VIEW\AddSiteView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A3009C854EADA76FCB24F57E2E5C238B"
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


namespace ShreeMehtaPublicity.VIEW
{


    /// <summary>
    /// AddSiteView
    /// </summary>
    public partial class AddSiteView : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 51 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SiteImage;

#line default
#line hidden


#line 61 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteName;

#line default
#line hidden


#line 69 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteHeight;

#line default
#line hidden


#line 70 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteWidth;

#line default
#line hidden


#line 73 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteAmount;

#line default
#line hidden


#line 75 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteAddress;

#line default
#line hidden


#line 90 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;

#line default
#line hidden


#line 95 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;

#line default
#line hidden


#line 104 "..\..\..\VIEW\AddSiteView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OKButton;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ShreeMehtaPublicity;component/view/addsiteview.xaml", System.UriKind.Relative);

#line 1 "..\..\..\VIEW\AddSiteView.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.AddSiteWindow = ((ShreeMehtaPublicity.VIEW.AddSiteView)(target));

#line 7 "..\..\..\VIEW\AddSiteView.xaml"
                    this.AddSiteWindow.Closing += new System.ComponentModel.CancelEventHandler(this.AddSiteWindow_Closing);

#line default
#line hidden
                    return;
                case 2:
                    this.SiteImage = ((System.Windows.Controls.Button)(target));
                    return;
                case 3:
                    this.SiteName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.SiteHeight = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.SiteWidth = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.SiteAmount = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.SiteAddress = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.Save = ((System.Windows.Controls.Button)(target));
                    return;
                case 9:
                    this.CloseButton = ((System.Windows.Controls.Button)(target));
                    return;
                case 10:
                    this.OKButton = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window AddSiteWindow;
    }
}

