using System;
using System.Collections.Generic;
using Android.Bluetooth;
using Plugin.BluetoothLE;
using Xamarin.Forms;
using XRDemo.BluetoothDemo;
using XRDemo.Droid.BTDemo;

[assembly: Xamarin.Forms.Dependency(typeof(XRDemo.Droid.BTDemo.BluetoothDemo))]
namespace XRDemo.Droid.BTDemo
{
    public partial class BluetoothDemo : ContentPage, IPage
    {
        public BluetoothDemo()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            btnBTON.Clicked += BtnBTON_Clicked;
            btnBTOFF.Clicked += BtnBTOFF_Clicked;
            btnBTScan.Clicked += BtnBTScan_Clicked;
            imgBack.Clicked += ImgBack_Clicked;
        }

        private async void ImgBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void BtnBTScan_Clicked(object sender, EventArgs e)
        {
        }


        void BtnBTOFF_Clicked(object sender, EventArgs e)
        {
            BluetoothAndroid();
            Disable();
        }

        void BtnBTON_Clicked(object sender, EventArgs e)
        {
            BluetoothAndroid();
            Enable();

            CrossBleAdapter.Current.Scan().Subscribe(async scanResult =>
            {
                string name = scanResult.AdvertisementData.LocalName;
                string id = scanResult.Device.Name;
                int power = scanResult.AdvertisementData.TxPower;

                await DisplayAlert(name, id, ""+power);


            });
        }

        private BluetoothManager _manager;

        public void BluetoothAndroid()
        {
            _manager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
        }

        public void Enable()
        {
            _manager.Adapter.Enable();
        }

        public void Disable()
        {
            _manager.Adapter.Disable();
        }
    }
}
