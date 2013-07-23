using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using C4G.Models;
using C4G.WebServices;
using Newtonsoft.Json;
using C4G.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace C4G.DataModels
{
    public class Images_DataModel : List<ImageData>
    {
        public static ObservableCollection<ImageData> DataCollection { get; set; }

        public Images_DataModel()
        {
            httpCall();
            BuildCollection();
        }

        public ObservableCollection<ImageData> BuildCollection()
        {
            //DataCollection = new ObservableCollection<ImageData>()
            //{
            //    new ImageData(new Uri("/Assets/logo.png", UriKind.RelativeOrAbsolute),"Rahul"),
            //    new ImageData(new Uri("/Assets/AlignmentGrid.png", UriKind.RelativeOrAbsolute),"Radha"),
            //    new ImageData(new Uri("/Assets/AlignmentGrid.png", UriKind.RelativeOrAbsolute),"Parag"),
            //    new ImageData(new Uri("/Assets/logo.png", UriKind.RelativeOrAbsolute),"Manish")
            //};

            DataCollection = new ObservableCollection<ImageData>();
            DataCollection.Add(new ImageData(new Uri("/Assets/logo.png", UriKind.RelativeOrAbsolute), "Rahul"));
            return DataCollection;
        }

        public void httpCall()
        {
            NetworkAdapter adapter = new NetworkAdapter();
            adapter.openHttpCall(WSUrl.BASE_URL);
        }

        public static void getResponce(String responce)
        {
            try
            {
                var rootObject = JsonConvert.DeserializeObject<RootAuthenticate>(responce);
                foreach (var blog in rootObject.catagories)
                {
                    DataCollection.Add(new ImageData(new Uri(WSUrl.BASE_URL_IMAGES + blog.image, UriKind.RelativeOrAbsolute), "Rahul"));                    
                }
                //Dismiss ProgressBar
                var progressBar = UIHelper.FindChild<ProgressBar>(Application.Current.RootVisual, "DownloadProgress");                
                progressBar.Visibility = Visibility.Collapsed;
                progressBar.IsEnabled = false;
            }
            catch (Exception)
            {
            }
        }
    }
}
