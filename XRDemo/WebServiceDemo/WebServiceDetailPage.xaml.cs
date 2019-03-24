using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XRDemo.WebServiceDemo
{
    public partial class WebServiceDetailPage : ContentPage
    {
        public WebServiceDetailPage()
        {
            InitializeComponent();
            init();
            setListener();
        }

        public void init()
        {
            listView.IsVisible = false;
            delayIndicator.IsVisible = false;
        }

        public void setListener()
        {
            btnLoadDataFromWebService.Clicked += BtnLoadDataFromWebService_Clicked;
        }

        void BtnLoadDataFromWebService_Clicked(object sender, EventArgs e)
        {
            getResponse();
        }

        public async void getResponse()
        {
            showDelayIndicator(true);

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://api.myjson.com/bins/gnq66"),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                HttpContent content = response.Content;
                var json = await content.ReadAsStringAsync();

                getObjectFromJSON(json);
            }

            showDelayIndicator(false);
        }

        public void getObjectFromJSON(string json)
        {
            var tr = JsonConvert.DeserializeObject<List<Monkey>>(json);

            ObservableCollection<Monkey> trends = new ObservableCollection<Monkey>(tr);

            listView.ItemsSource = trends;

        }

        public void showDelayIndicator(bool isRunning)
        {
            listView.IsVisible = !isRunning;
            delayIndicator.IsRunning = isRunning;
            delayIndicator.IsVisible = isRunning;
        }

    }
}
