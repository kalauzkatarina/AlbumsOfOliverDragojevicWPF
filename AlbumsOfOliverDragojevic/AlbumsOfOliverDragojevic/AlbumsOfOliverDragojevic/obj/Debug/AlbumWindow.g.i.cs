﻿#pragma checksum "..\..\AlbumWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E31A9BF23E05878D26F2FB2C14A91C5491BE96E7474EC4E32A4F0336D11D6C92"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AlbumsOfOliverDragojevic;
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


namespace AlbumsOfOliverDragojevic {
    
    
    /// <summary>
    /// AlbumWindow
    /// </summary>
    public partial class AlbumWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 37 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path UIPath;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AdminControlStackPanel;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SelectAllCheckBox;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewAlbumButton;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteAlbumButton;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ExitButtonStackPanel;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitFromAlbumsButton;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AlbumsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\AlbumWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn CheckBoxDataGridTemplateColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/AlbumsOfOliverDragojevic;component/albumwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AlbumWindow.xaml"
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
            
            #line 13 "..\..\AlbumWindow.xaml"
            ((AlbumsOfOliverDragojevic.AlbumWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UIPath = ((System.Windows.Shapes.Path)(target));
            return;
            case 3:
            this.AdminControlStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.SelectAllCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 106 "..\..\AlbumWindow.xaml"
            this.SelectAllCheckBox.Checked += new System.Windows.RoutedEventHandler(this.SelectAllCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 110 "..\..\AlbumWindow.xaml"
            this.SelectAllCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.SelectAllCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddNewAlbumButton = ((System.Windows.Controls.Button)(target));
            
            #line 118 "..\..\AlbumWindow.xaml"
            this.AddNewAlbumButton.Click += new System.Windows.RoutedEventHandler(this.AddNewAlbumButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteAlbumButton = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\AlbumWindow.xaml"
            this.DeleteAlbumButton.Click += new System.Windows.RoutedEventHandler(this.DeleteAlbumButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ExitButtonStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.ExitFromAlbumsButton = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\AlbumWindow.xaml"
            this.ExitFromAlbumsButton.Click += new System.Windows.RoutedEventHandler(this.ExitFromAlbumsButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AlbumsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.CheckBoxDataGridTemplateColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
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
            case 11:
            
            #line 189 "..\..\AlbumWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.AlbumCheckBox_Click);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 214 "..\..\AlbumWindow.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

