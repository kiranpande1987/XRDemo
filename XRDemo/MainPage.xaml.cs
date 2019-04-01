using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XRDemo.BasicUIDemo;
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
        }

    }
}
