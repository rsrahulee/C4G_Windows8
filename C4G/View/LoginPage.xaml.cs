using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;
using C4G.WebServices;
using C4G.Helpers;
using Newtonsoft.Json;
using C4G.Models;

namespace C4G.View
{
    public partial class LoginPage : PhoneApplicationPage, WSInterface
    {
        private Popup popup;

        public LoginPage()
        {
            InitializeComponent();

            showPopup();
            StartLoadingData();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (userId.Text.Equals("") || userPass.Password.Equals(""))
            {
                MessageBox.Show("Please enter your credentials");
            }
            else
            {
                httpCall();
            }
        }

        private void showPopup()
        {
            popup = new Popup();
            popup.Child = new SplashScreen();
            popup.IsOpen = true;
        }

        private void StartLoadingData()
        {
            BackgroundWorker backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
            });
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);
        }

        public void httpCall()
        {
            NetworkAdapter adapter = new NetworkAdapter();
            adapter.SendPost(new Uri(WSUrl.LOGIN_URL), WSUrl.PARAMS, this);
        }

        public void CallWS_POST(String myResult)
        {
            getResponce(myResult);
        }

        public void getResponce(String responce)
        {
            try
            {
                var rootObject = JsonConvert.DeserializeObject<Login>(responce);
                if (rootObject.login.Equals("True"))
                {
                    String strApiKey = rootObject.api_key;
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show("Wrong credentials");
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}