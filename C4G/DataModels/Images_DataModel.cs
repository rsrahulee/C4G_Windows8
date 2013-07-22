using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using C4G.Models;
using C4G.WebServices;
using System.Net;
using Newtonsoft.Json;

namespace C4G.DataModels
{
    public class Images_DataModel : List<ImageData>
    {
        public ObservableCollection<ImageData> DataCollection { get; set; }

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
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://192.168.10.192:3000/catagories/get_data.json?device=1x"));
        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rootObject = JsonConvert.DeserializeObject<RootObject>(e.Result);
            foreach (var blog in rootObject.catagories)
            {
                DataCollection.Add(new ImageData(new Uri("http://192.168.10.192:3000" + blog.image, UriKind.RelativeOrAbsolute), "Rahul"));
            }
        }
    }
}
