﻿#pragma checksum "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F5ABD87352AF4934C2A1A63AB4C8529C792C1467"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using Template.Frontend.DataContexts;


namespace Template.Frontend.Windows.Dialogs {
    
    
    /// <summary>
    /// AddParameterDialog
    /// </summary>
    public partial class AddParameterDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_ParameterName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_ParameterType;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Save;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Cancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Template.Frontend;component/windows/dialogs/addparameterdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBox_ParameterName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ComboBox_ParameterType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Button_Save = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
            this.Button_Save.Click += new System.Windows.RoutedEventHandler(this.Button_Save_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\..\Windows\Dialogs\AddParameterDialog.xaml"
            this.Button_Cancel.Click += new System.Windows.RoutedEventHandler(this.Button_Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
