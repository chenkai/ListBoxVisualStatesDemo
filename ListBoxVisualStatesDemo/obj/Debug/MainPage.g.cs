﻿#pragma checksum "H:\open source project\Sample\RefreshListBox\ListBoxVisualStatesDemo\ListBoxVisualStatesDemo\ListBoxVisualStatesDemo\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "38026321833A823BFB2142D95B2A3D90"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ListBoxVisualStatesDemo {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard AnimateTextSB;
        
        internal System.Windows.Media.Animation.DoubleAnimation FontAnimation;
        
        internal System.Windows.Media.Animation.ColorAnimation FontColorAnimation;
        
        internal System.Windows.Media.Animation.Storyboard AnimateSqueezeTextSB;
        
        internal System.Windows.Media.Animation.DoubleAnimation FontAnimationSqueeze;
        
        internal System.Windows.Media.Animation.ColorAnimation FontColorAnimationSqueeze;
        
        internal System.Windows.Controls.StackPanel LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.ListBox MainListBox;
        
        internal System.Windows.Controls.TextBlock scrollStartedTxb;
        
        internal System.Windows.Controls.TextBlock scrollCompletedTxb;
        
        internal System.Windows.Controls.TextBlock isScrollingTxb;
        
        internal System.Windows.Controls.TextBlock isBouncyTxb;
        
        internal System.Windows.Controls.TextBlock VCompressionTxb;
        
        internal System.Windows.Controls.TextBlock TopTxb;
        
        internal System.Windows.Controls.TextBlock BottomTxb;
        
        internal System.Windows.Controls.TextBlock HCompressionTxb;
        
        internal System.Windows.Controls.TextBlock LeftTxb;
        
        internal System.Windows.Controls.TextBlock RightTxb;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ListBoxVisualStatesDemo;component/MainPage.xaml", System.UriKind.Relative));
            this.AnimateTextSB = ((System.Windows.Media.Animation.Storyboard)(this.FindName("AnimateTextSB")));
            this.FontAnimation = ((System.Windows.Media.Animation.DoubleAnimation)(this.FindName("FontAnimation")));
            this.FontColorAnimation = ((System.Windows.Media.Animation.ColorAnimation)(this.FindName("FontColorAnimation")));
            this.AnimateSqueezeTextSB = ((System.Windows.Media.Animation.Storyboard)(this.FindName("AnimateSqueezeTextSB")));
            this.FontAnimationSqueeze = ((System.Windows.Media.Animation.DoubleAnimation)(this.FindName("FontAnimationSqueeze")));
            this.FontColorAnimationSqueeze = ((System.Windows.Media.Animation.ColorAnimation)(this.FindName("FontColorAnimationSqueeze")));
            this.LayoutRoot = ((System.Windows.Controls.StackPanel)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.MainListBox = ((System.Windows.Controls.ListBox)(this.FindName("MainListBox")));
            this.scrollStartedTxb = ((System.Windows.Controls.TextBlock)(this.FindName("scrollStartedTxb")));
            this.scrollCompletedTxb = ((System.Windows.Controls.TextBlock)(this.FindName("scrollCompletedTxb")));
            this.isScrollingTxb = ((System.Windows.Controls.TextBlock)(this.FindName("isScrollingTxb")));
            this.isBouncyTxb = ((System.Windows.Controls.TextBlock)(this.FindName("isBouncyTxb")));
            this.VCompressionTxb = ((System.Windows.Controls.TextBlock)(this.FindName("VCompressionTxb")));
            this.TopTxb = ((System.Windows.Controls.TextBlock)(this.FindName("TopTxb")));
            this.BottomTxb = ((System.Windows.Controls.TextBlock)(this.FindName("BottomTxb")));
            this.HCompressionTxb = ((System.Windows.Controls.TextBlock)(this.FindName("HCompressionTxb")));
            this.LeftTxb = ((System.Windows.Controls.TextBlock)(this.FindName("LeftTxb")));
            this.RightTxb = ((System.Windows.Controls.TextBlock)(this.FindName("RightTxb")));
        }
    }
}
