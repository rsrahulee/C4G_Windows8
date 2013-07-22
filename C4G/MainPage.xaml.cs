using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Net;
using C4G.WebServices;

namespace C4G
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //NetworkAdapter adap = new NetworkAdapter();
            //adap.GetToken();
            //adap.httpCall();

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
    }
}