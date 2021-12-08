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
    public partial class RecentRecord : ContentPage
    {
        Record r;
        public RecentRecord()
        {
            InitializeComponent();

            changeToMostRecentRecord();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            changeToMostRecentRecord();
        }

        private async void changeToMostRecentRecord()
        {

            string url = "https://louenes099.pythonanywhere.com/pi/api/get/last";
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            Console.WriteLine(result);
            var resultsObject = JArray.Parse(result);

            Console.WriteLine(resultsObject);

            int id = resultsObject[0][0].ToObject<int>();
            string time = resultsObject[0][1].ToString();
            double temp = resultsObject[0][2].ToObject<double>();
            double hum = resultsObject[0][3].ToObject<double>();

            r = new Record(id, time, temp, hum);
            try
            {
                xtime.Text = r.dateTime;
                xtemp.Text = r.Temp.ToString() + "°C";
                xhum.Text = r.Hum.ToString() + "%";
                xfanStatus.Text = r.FanOn == true ? "On" : "Off";
            }
            catch (Exception e)
            {
                warning.Text = "Error occured while getting data: " + e;
            }
        }
    }
}