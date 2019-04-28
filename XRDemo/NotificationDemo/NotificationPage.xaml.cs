using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Plugin.LocalNotifications;

namespace XRDemo.NotificationDemo
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            imgBack.Clicked += ImgBack_Clicked;
        }

        private async void ImgBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Title", "This is local notification");
        }
    }
}
