﻿#pragma checksum "..\..\image_edit.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6832CC51EF20225CD84F544CD9A3F895"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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


namespace klm {
    
    
    /// <summary>
    /// image_edit
    /// </summary>
    public partial class image_edit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\image_edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image im;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\image_edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock im_text;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\image_edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image tr_im;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\image_edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider loc;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\image_edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sc;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\image_edit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider loc_y;
        
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
            System.Uri resourceLocater = new System.Uri("/klm;component/image_edit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\image_edit.xaml"
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
            
            #line 11 "..\..\image_edit.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\image_edit.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.im = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.im_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tr_im = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.loc = ((System.Windows.Controls.Slider)(target));
            
            #line 20 "..\..\image_edit.xaml"
            this.loc.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.loc_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sc = ((System.Windows.Controls.Slider)(target));
            
            #line 30 "..\..\image_edit.xaml"
            this.sc.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sc_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.loc_y = ((System.Windows.Controls.Slider)(target));
            
            #line 31 "..\..\image_edit.xaml"
            this.loc_y.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.loc_y_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

