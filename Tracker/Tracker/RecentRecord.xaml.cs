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
    public partial class RecentRecord : ContentPage
    {
        //Record r;
        string token;
        public RecentRecord(string response)
        {
            InitializeComponent();
            token = response;
            changeToMostRecentRecord();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            changeToMostRecentRecord();
        }

        private async void changeToMostRecentRecord()
        {
            var client = new RestClient("https://louenes099.pythonanywhere.com/pi/api/get/last");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-tokens", token);
            IRestResponse response = client.Execute(request);


            var record = response.Content;
            Console.WriteLine(record);
            var resultsObject = JArray.Parse(record);

            try
            {
                var r = JsonConvert.DeserializeObject<List<Record>>(record);

                xtime.Text = r[0].time;
                xtemp.Text = r[0].temp.ToString() + "°C";
                xhum.Text = r[0].hum.ToString() + "%";
                xfanStatus.Text = r[0].FanOn == true ? "On" : "Off";
            }
            catch (Exception e)
            {
                warning.Text = "Error occured while getting data: " + e;
            }
        }
    }
}