using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace Tracker
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void recentRecord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecentRecord());
        }

        private async void historyRecords_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryRecords());
        }
    }
}
