using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using Windows.Web.Http;
using System.IO;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;

namespace TBDeCare_Laboran
{
    public partial class SubmitPage : PhoneApplicationPage
    {
        private string file = "";
        private string patient = "";
        private string server_url = "";

        public SubmitPage()
        {
            InitializeComponent();
        }


        //Code for initialization, capture completed, image availability events; also setting the source for the viewfinder.
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string finalfilepath = "";
            string patientid = "";

            if (NavigationContext.QueryString.TryGetValue("finalfilepath", out finalfilepath))
            {
                file = finalfilepath;
                TextBoxSputum.Text = finalfilepath;
            }
            if (NavigationContext.QueryString.TryGetValue("patientid", out patientid))
            {
                patient = patientid;
                TextBoxPatientID.Text = patient;
            }
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                Object value = localSettings.Values["TBDCServer"];

                if (value == null)
                {
                    localSettings.Values["TBDCServer"] = "N/A";
                    MessageBox.Show("Error: server setting is not set yet!");
                    NavigationService.Navigate(new Uri("/SettingServerPage.xaml", UriKind.Relative));
                    return;
                }
                else
                {
                    server_url = value.ToString() + "/patient/lab_result/store";
                }

                IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream targetStream = isStore.OpenFile(file, FileMode.Open, FileAccess.Read);


                IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.OpenFile(file, FileMode.Open, FileAccess.Read);

                HttpMultipartFormDataContent multipartContent = new HttpMultipartFormDataContent();

                multipartContent.Add(new HttpStreamContent(isolatedStorageFileStream.AsInputStream()), "photo", file);
                multipartContent.Add(new HttpStringContent("admin"), "username");
                multipartContent.Add(new HttpStringContent("djangoadmin"), "password");
                multipartContent.Add(new HttpStringContent(patient), "patient_id");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync(new Uri(server_url), multipartContent);

                String responseStr = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(responseStr);

                if (responseStr.Contains("\"status\": \"success\", \"message\": \"Photo uploaded!\""))
                {
                    if (MessageBox.Show("Sputum has been succesfully assigned to Patient " + patient + " !") == MessageBoxResult.OK)
                    {
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: check server settings!");
                NavigationService.Navigate(new Uri("/SettingServerPage.xaml", UriKind.Relative));
                return;
            }
        }
    }
}