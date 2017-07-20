using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TBDeCare_Laboran
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object value = localSettings.Values["TBDCServer"];

            if (value == null)
            {
                localSettings.Values["TBDCServer"] = "http://0fccf53a.ngrok.io";
            }
            else
            {
                localSettings.Values["TBDCServer"] = value;
            }
        }

        private void CaptureButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CameraPage.xaml?msg=" + TextBoxPatientID.Text, UriKind.Relative));   
        }

        private void PatientID_Changed(object sender, RoutedEventArgs e)
        {
            if (TextBoxPatientID.Text.Trim() != "")
            {
                ButtonCapture.IsEnabled = true;
            }
            else
            {
                ButtonCapture.IsEnabled = false;
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingServerPage.xaml", UriKind.Relative));
        }
    }
}