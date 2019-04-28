using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BluetoothLE;
using Plugin.LocalNotifications;
using Plugin.LocalNotifications.Abstractions;
using Xamarin.Forms;
using XRDemo.BasicUIDemo;
using XRDemo.BluetoothDemo;
using XRDemo.CPPMathDemo;
using XRDemo.NotificationDemo;
using XRDemo.SqliteDemo;
using XRDemo.UIComponentDemo;
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
            }

            if (itemSelectedData.Equals("Bluetooth Demo"))
            {
                Navigation.PushModalAsync((Xamarin.Forms.Page)DependencyService.Get<IPage>());
            }

            if (itemSelectedData.Equals("UI Component Demo"))
            {
                Navigation.PushModalAsync(new UIComponentPage());
            }
        }
    }
}
