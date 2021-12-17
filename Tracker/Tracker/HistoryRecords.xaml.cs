using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryRecords : ContentPage
    {
        string token;
        //Record r;
        public List<Record> records { get; set; }
        public HistoryRecords(string response)
        {
            InitializeComponent();
            BindingContext = this;

            token = response;
            records = new List<Record>();
            changeToMostRecentRecord();

        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            changeToMostRecentRecord();
        }

        private async void changeToMostRecentRecord()
        {


            string link;
            if(int.TryParse(startBoundary.Text, out int n) && int.TryParse(finishBoundary.Text, out int m))
            {
                link = "https://louenes099.pythonanywhere.com/pi/api/get/" + startBoundary.Text + "/" + finishBoundary.Text;
            }
            else
            {
                link = "https://louenes099.pythonanywhere.com/pi/api/get/all";
            }
            


            var client = new RestClient(link);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-tokens", token);
            IRestResponse response = client.Execute(request);


            var record = response.Content;
            Console.WriteLine(record);
            var resultsObject = JArray.Parse(record);
                        
            try
            {

                records = JsonConvert.DeserializeObject<List<Record>>(record);
                OnAppearing(records);

            }
            catch (Exception e)
            {
                warning.Text = "Error occured while getting data: " + e;
            }
        }
        protected void OnAppearing(List<Record> records)
        {
            base.OnAppearing();
            collectionView.ItemsSource = records;
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Chart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Chart(records));
        }

        private async void HumChart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HumidityChart(records));
        }
    }
}