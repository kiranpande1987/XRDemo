using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XRDemo.UIComponentDemo
{
    public partial class UIComponentPage : ContentPage
    {
        public UIComponentPage()
        {
            InitializeComponent();

            //initAsync();

            btnClick.Clicked += BtnClick_ClickedAsync;

            imgBack.Clicked += ImgBack_Clicked;
        }

        private async void ImgBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void BtnClick_ClickedAsync(object sender, EventArgs e)
        {
            await pb.ProgressTo(.8, 3000, Easing.Linear);
        }

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            double newValue = e.NewValue;
            lblStepper.Text = "Value : " + newValue;
        }
    }
}
