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
    public partial class SettingServerPage : PhoneApplicationPage
    {
        public SettingServerPage()
        {
            InitializeComponent();
        }

        //Code for initialization, capture completed, image availability events; also setting the source for the viewfinder.
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object value = localSettings.Values["TBDCServer"];

            if (value == null)
            {
                localSettings.Values["TBDCServer"] = "N/A";
                TextBoxSetting.Text = "N/A";
            }
            else
            {
                localSettings.Values["TBDCServer"] = value;
                TextBoxSetting.Text = value.ToString();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            // Create a simple setting
            localSettings.Values["TBDCServer"] = TextBoxSetting.Text;
            MessageBox.Show("Server setting is succesfully updated");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}