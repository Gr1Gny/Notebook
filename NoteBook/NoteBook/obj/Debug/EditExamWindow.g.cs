﻿#pragma checksum "..\..\EditExamWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2F5FC05B8AA7B19D648EE547D4F1F8678210645FAC961CEDD3CA1B78C0CD7186"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using NoteBook;
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


namespace NoteBook {
    
    
    /// <summary>
    /// EditExamWindow
    /// </summary>
    public partial class EditExamWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox modules;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox absent;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox score;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prof;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button valider;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\EditExamWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox coef;
        
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
            System.Uri resourceLocater = new System.Uri("/NoteBook;component/editexamwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditExamWindow.xaml"
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
            this.modules = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.absent = ((System.Windows.Controls.CheckBox)(target));
            
            #line 12 "..\..\EditExamWindow.xaml"
            this.absent.Checked += new System.Windows.RoutedEventHandler(this.Check);
            
            #line default
            #line hidden
            
            #line 12 "..\..\EditExamWindow.xaml"
            this.absent.Unchecked += new System.Windows.RoutedEventHandler(this.NotCheck);
            
            #line default
            #line hidden
            return;
            case 3:
            this.score = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.prof = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.valider = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\EditExamWindow.xaml"
            this.valider.Click += new System.Windows.RoutedEventHandler(this.Validate);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cancel = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\EditExamWindow.xaml"
            this.cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            case 8:
            this.coef = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

