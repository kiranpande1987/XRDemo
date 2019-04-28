using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XRDemo.BluetoothDemo;
using XRDemo.iOS.BTDemo;

[assembly: Xamarin.Forms.Dependency(typeof(XRDemo.iOS.BTDemo.BluetoothDemo))]
namespace XRDemo.iOS.BTDemo
{
    public partial class BluetoothDemo : ContentPage, IPage
    {
        public BluetoothDemo()
        {
            InitializeComponent();
            imgBack.Clicked += ImgBack_Clicked;
        }

        private async void ImgBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
