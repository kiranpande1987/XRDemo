using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Plugin.LocalNotifications.Abstractions;
using Xamarin.Forms;
using XRDemo.BasicUIDemo;
using XRDemo.CPPMathDemo;
using XRDemo.NotificationDemo;
using XRDemo.SqliteDemo;
using XRDemo.WebServiceDemo;

namespace XRDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            imgBack.Clicked += ImgBack_Clicked;
        }

        private void ImgBack_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        void OnListViewItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            string itemSelectedData = e.Item as string;

            if (itemSelectedData.Equals("Basic UI Demo"))
            {
                Navigation.PushModalAsync(new BasicUIDetailPage());
            }

            if (itemSelectedData.Equals("WebService Demo"))
            {
                Navigation.PushModalAsync(new WebServiceDetailPage());
            }

            if (itemSelectedData.Equals("Database Demo"))
            {
                Navigation.PushModalAsync(new NotePage());
            }

            if (itemSelectedData.Equals("CPP Demo"))
            {
                Navigation.PushModalAsync(new CPPMathPage());
            }

            if (itemSelectedData.Equals("Notification Demo"))
            {
                Navigation.PushModalAsync(new NotificationPage());
                //if(Device.RuntimePlatform == Device.iOS)
                //{
                //    var content = new UNMutableNotificationContent()
                //    {
                //        Title = "Critical alert title",
                //        Body = "Text of the critical alert",
                //        CategoryIdentifier = "my-critical-alert-category",
                //        Sound = UNNotificationSound.DefaultCriticalSound
                //        //Sound = UNNotificationSound.GetCriticalSound("my_critical_sound.m4a", 1.0f)
                //    };

                //    var request = UNNotificationRequest.FromIdentifier(
                //        Guid.NewGuid().ToString(),
                //        content,
                //        UNTimeIntervalNotificationTrigger.CreateTrigger(3, false)
                //    );

                //    var center = UNUserNotificationCenter.Current;
                //    center.AddNotificationRequest(request, null);
                //}
                //else
                //{
                //    ILocalNotifications localNotifications = DependencyService.Get<ILocalNotifications>();
                //    localNotifications.Show("Test", "Local notification alert", 1);
                //}
            }
        }



        //void CreateNotificationChannel()
        //{
        //    if (Build.VERSION.SdkInt < BuildVersionCodes.O)
        //    {
        //        // Notification channels are new in API 26 (and not a part of the
        //        // support library). There is no need to create a notification
        //        // channel on older versions of Android.
        //        return;
        //    }

        //    string channelName = "Channel";
        //    string channelDescription = "Channel Description";
        //    var channel = new Android.App.NotificationChannel("10", channelName, NotificationImportance.Default)
        //    {
        //        Description = channelDescription
        //    };

        //    var notificationManager = (NotificationManager)GetSystemService(NotificationService);
        //    notificationManager.CreateNotificationChannel(channel);
        //}

    }
}
