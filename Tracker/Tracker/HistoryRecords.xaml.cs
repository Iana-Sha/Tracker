using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        Record r;
        public List<Record> records { get; set; }
        public HistoryRecords()
        {
            InitializeComponent();
            records = new List<Record>();
            changeToMostRecentRecord();
        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            changeToMostRecentRecord();
        }

        private async void changeToMostRecentRecord()
        {

            string url = "https://louenes099.pythonanywhere.com/pi/api/get/all";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            //records = JsonConvert.DeserializeObject<List<Record>>(result);

            //Console.WriteLine(records[0]);

            var resultsObject = JArray.Parse(result);
            try
            {
                foreach (var res in resultsObject)
                {

                    int id = res[0].ToObject<int>();
                    string time = res[1].ToString();
                    double temp = res[2].ToObject<double>();
                    double hum = res[3].ToObject<double>();
                    Record rec = new Record(id, time, temp, hum);
                    records.Add(rec);
                }

                BindingContext = this;

            }
            catch (Exception e)
            {
                warning.Text = "Error occured while getting data: " + e;
            }
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Chart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Chart(records));
        }
    }
}