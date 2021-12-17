using RestSharp;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = "";
                var pwd = "";
                user = username.Text;
                pwd = password.Text;
                string par = "{\"name\": \"" + user + "\", \"password\": \"" + pwd + "\"}";
                var client = new RestClient("https://louenes099.pythonanywhere.com/register");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                request.AddParameter("application/json", par, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new MainPage());

                }
                else
                {
                    await DisplayAlert("Registration failed", "Error", "OK");
                }
            }
            catch(Exception ex)
            {
                error.Text = ex.Message;

            }
        }
    }
}