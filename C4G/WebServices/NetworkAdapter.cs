using C4G.DataModels;
using C4G.Helpers;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace C4G.WebServices
{
    class NetworkAdapter
    {
        //public void GetToken()
        //{
        //    HttpWebRequest hwr = WebRequest.Create(new Uri("http://192.168.10.192:3000/catagories/get_data.json?device=1x")) as HttpWebRequest;
        //    hwr.Method = "POST";
        //    //hwr.ContentType = "application/x-www-form-urlencoded";
        //    hwr.BeginGetRequestStream(new AsyncCallback(RetrieveTokenEndpointResponse), hwr);
        //}

        //private void SendTokenEndpointRequest(IAsyncResult rez)
        //{
        //    HttpWebRequest hwr = rez.AsyncState as HttpWebRequest;
        //    byte[] bodyBits = Encoding.UTF8.GetBytes(string.Format("grant_type=authorization_code&code={0}&client_id={1}&redirect_uri={2}", app.Code, app.ClientID, HttpUtility.UrlEncode(app.RedirectUri)));
        //    Stream st = hwr.EndGetRequestStream(rez);
        //    st.Write(bodyBits, 0, bodyBits.Length);
        //    st.Close();
        //    hwr.BeginGetResponse(new AsyncCallback(RetrieveTokenEndpointResponse), hwr);
        //}

        //private void RetrieveTokenEndpointResponse(IAsyncResult rez)
        //{
        //    HttpWebRequest hwr = rez.AsyncState as HttpWebRequest;
        //    HttpWebResponse resp = hwr.EndGetResponse(rez) as HttpWebResponse;

        //    StreamReader sr = new StreamReader(resp.GetResponseStream());
        //    string responseString = sr.ReadToEnd();
        //    JObject jo = JsonConvert.DeserializeObject(responseString) as JObject;
        //    //app.AccessToken = (string)jo["access_token"];

        //    //Dispatcher.BeginInvoke(() =>
        //    //{
        //    //    NavigationService.GoBack();
        //    //});
        //}

        //public void DownloadStringHttpCall()
        //{
        //    //var client = new HttpClient();
        //    //HttpResponseMessage response = await client.GetAsync(new Uri("http://myapi.com/"));
        //    //var jsonString = await response.Content.ReadAsStringAsync();

        //    WebClient webClient = new WebClient();
        //    webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
        //    webClient.DownloadStringAsync(new Uri("http://192.168.10.192:3000/catagories/get_data.json?device=1x"));

        //WebClient webClient = new WebClient();
        //webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(OpenReadCompleted);
        //webClient.OpenReadAsync(new Uri("http://192.168.10.192:3000/catagories/get_data.json?device=1x"));

        //}

        //private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    var rootObject = JsonConvert.DeserializeObject<RootObject>(e.Result);
        //    foreach (var blog in rootObject.catagories)
        //    {
        //        Console.WriteLine(blog.image);
        //    }
        //}

        public void openHttpCall(String url)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(httpCallCompleted);
            webClient.DownloadStringAsync(new Uri(url));
        }

        private void httpCallCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            switch (Constants.fromWhereCalled)
            {
                case 0:
                    MainPage.getResponce(e.Result.ToString());
                    break;
                case 1:
                    Images_DataModel.getResponce(e.Result.ToString());
                    break;
            }
        }

        public void SendPost(Uri uri)
        {
            var webClient = new WebClient();

            //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.UploadStringCompleted += this.sendPostCompleted;
            webClient.UploadStringAsync(uri, WSUrl.PARAMS);
        }

        private void sendPostCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            // Handle result
            Console.WriteLine("HTTP POST Result: {0}", e.Result);
        }
    }

    //public class MyBlogList
    //{
    //    //public int ID { get; set; }
    //    //public string TYPE { get; set; }
    //    //public string TITLE { get; set; }
    //    //public string PRICE { get; set; }
    //    public string catagories { get; set; }
    //    public string success { get; set; }
    //    public string image { get; set; }
    //}
    //public class RootObject
    //{
    //    public List<MyBlogList> catagories { get; set; }
    //    public String success { get; set; }
    //}
}
