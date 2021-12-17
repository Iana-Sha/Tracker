using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace Tracker
{
    public partial class MainPage : ContentPage
    {
        User u;
        public MainPage()
        {
            InitializeComponent();
        }
        //await Navigation.PushAsync(new HistoryRecords());
       
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            try { 
            string user = username.Text;
            string pwd = password.Text;
            u = new User(user, pwd);
            var par = Newtonsoft.Json.JsonConvert.SerializeObject(u);
            var client = new RestClient("https://louenes099.pythonanywhere.com/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                               .GetBytes(user + ":" + pwd));
            request.AddHeader("Authorization", "Basic " + encoded);
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            
            var r = response.Content.Replace("{\"token\":\"b'", "").Replace("'\"}\n", "");
            //var r = request.ToString().Replace("b'", "").Replace("'","");
                Console.WriteLine(r);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new MenuPage(r));

                }
                else
                {
                    await DisplayAlert("Authorization failed", "Error", "OK");
                }
            }
            catch(Exception ex)
            {
                error.Text = ex.Message;
            }
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
