using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;
using C4G.View;
using System.ComponentModel;
using System.Threading;
using C4G.WebServices;
using C4G.Helpers;
using System;
using Newtonsoft.Json;
using C4G.Models;

namespace C4G
{
    public partial class MainPage : PhoneApplicationPage
    {
        Popup popup;

        public MainPage()
        {
            InitializeComponent();

            Constants.fromWhereCalled = WSFromWhereCalled.fromLoginPage;
            //showPopup();
            //StartLoadingData();

            // Set the data context of the listbox control to the sample data
            //DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        //private void showPopup()
        //{
        //    popup = new Popup();
        //    popup.Child = new SplashScreen();
        //    popup.IsOpen = true;
        //}

        //private void StartLoadingData()
        //{
        //    BackgroundWorker backroungWorker = new BackgroundWorker();
        //    backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
        //    backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
        //    backroungWorker.RunWorkerAsync();
        //}

        //void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    this.Dispatcher.BeginInvoke(() =>
        //    {
        //        this.popup.IsOpen = false;
        //    });
        //}

        //void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // Do some data loading on a background
        //    // We'll just sleep for the demo
        //    Thread.Sleep(2000);
        //    httpCall();
        //}

        //public void httpCall()
        //{
        //    NetworkAdapter adapter = new NetworkAdapter();
        //    //adapter.openHttpCall(WSUrl.LOGIN_URL);
        //    adapter.SendPost(new Uri(WSUrl.LOGIN_URL), WSUrl.PARAMS);
        //}

        //public static void getResponce(String responce)
        //{
        //    try
        //    {
        //        var rootObject = JsonConvert.DeserializeObject<Login>(responce);
        //        if (rootObject.login.Equals("True"))
        //        {
        //            String strApiKey = rootObject.api_key;
        //        }
        //        else
        //        {
        //            CustomMessageBox box = new CustomMessageBox();
        //            box.Show();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
    }
}