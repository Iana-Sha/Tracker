using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        string response;
        public MenuPage(string response)
        {
            InitializeComponent();
            this.response = response;
        }

        private async void recentRecord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecentRecord(response));
        }

        private async void historyRecords_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryRecords(response));
        }
    }
}