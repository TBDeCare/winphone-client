﻿#pragma checksum "C:\Users\mure\Documents\Visual Studio 2015\Projects\TBDeCare Laboran\TBDeCare Laboran\SubmitPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B91907F416616383A08F73F49EDCE2B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace TBDeCare_Laboran {
    
    
    public partial class SubmitPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox TextBoxPatientID;
        
        internal System.Windows.Controls.TextBox TextBoxSputum;
        
        internal System.Windows.Controls.Button ButtonCapture;
        
        internal System.Windows.Controls.Button ButtonSubmit;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/TBDeCare%20Laboran;component/SubmitPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.TextBoxPatientID = ((System.Windows.Controls.TextBox)(this.FindName("TextBoxPatientID")));
            this.TextBoxSputum = ((System.Windows.Controls.TextBox)(this.FindName("TextBoxSputum")));
            this.ButtonCapture = ((System.Windows.Controls.Button)(this.FindName("ButtonCapture")));
            this.ButtonSubmit = ((System.Windows.Controls.Button)(this.FindName("ButtonSubmit")));
        }
    }
}

