﻿#pragma checksum "..\..\MedewerkerMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6D7964FDA461E1946E168AB1484F25AA7A2C5CA7B743A58BEC470F0246A19D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using P4WPF;
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


namespace P4WPF {
    
    
    /// <summary>
    /// MedewerkerMenu
    /// </summary>
    public partial class MedewerkerMenu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\MedewerkerMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOrder;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MedewerkerMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btStatus;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MedewerkerMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btIngredients;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MedewerkerMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btLogout;
        
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
            System.Uri resourceLocater = new System.Uri("/P4WPF;component/medewerkermenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MedewerkerMenu.xaml"
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
            this.btOrder = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\MedewerkerMenu.xaml"
            this.btOrder.Click += new System.Windows.RoutedEventHandler(this.btOrder_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btStatus = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MedewerkerMenu.xaml"
            this.btStatus.Click += new System.Windows.RoutedEventHandler(this.btStatus_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btIngredients = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\MedewerkerMenu.xaml"
            this.btIngredients.Click += new System.Windows.RoutedEventHandler(this.btIngredients_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btLogout = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\MedewerkerMenu.xaml"
            this.btLogout.Click += new System.Windows.RoutedEventHandler(this.btLogout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

