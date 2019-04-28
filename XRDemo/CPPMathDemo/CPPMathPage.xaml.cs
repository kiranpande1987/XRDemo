using System;
using System.Collections.Generic;

using Xamarin.Forms;

using System.Diagnostics;
using MathFuncs;

namespace XRDemo.CPPMathDemo
{
    public partial class CPPMathPage : ContentPage
    {
        MyMathFuncs myMathFuncs;

        public CPPMathPage()
        {
            InitializeComponent();
            init();
            setListener();
        }

        public void init()
        {
            edtFirstNumber.Text = "0";
            edtSecondNumber.Text = "0";

            txtResult.Text = "Result : 0";
            imgBack.Clicked += ImgBack_Clicked;
        }

        private async void ImgBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public void setListener()
        {
            btnAddition.Clicked += BtnAddition_Clicked;
            btnSubtraction.Clicked += BtnSubtraction_Clicked;
            btnMultiplication.Clicked += BtnMultiplication_Clicked;
            btnDivision.Clicked += BtnDivision_Clicked;
        }

        void BtnDivision_Clicked(object sender, EventArgs e)
        {
            int num1 = checkEditText(edtFirstNumber);
            int num2 = checkEditText(edtSecondNumber);

            var result = myMathFuncs.Divide(num1, num2);

            txtResult.Text = "Result : " + result;
        }


        void BtnMultiplication_Clicked(object sender, EventArgs e)
        {
            int num1 = checkEditText(edtFirstNumber);
            int num2 = checkEditText(edtSecondNumber);

            var result = myMathFuncs.Multiply(num1, num2);

            txtResult.Text = "Result : " + result;
        }


        void BtnSubtraction_Clicked(object sender, EventArgs e)
        {
            int num1 = checkEditText(edtFirstNumber);
            int num2 = checkEditText(edtSecondNumber);

            var result = myMathFuncs.Subtract(num1, num2);

            txtResult.Text = "Result : " + result;
        }


        void BtnAddition_Clicked(object sender, EventArgs e)
        {
            int num1 = checkEditText(edtFirstNumber);
            int num2 = checkEditText(edtSecondNumber);

            var result = myMathFuncs.Add(num1, num2);

            txtResult.Text = "Result : " + result;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            myMathFuncs = new MyMathFuncs();
        }

        protected override void OnDisappearing()
        {
            //myMathFuncs.Dispose();
            base.OnDisappearing();
        }

        public int checkEditText(Entry entry)
        {
            if(entry != null)
            {
                if(!String.IsNullOrEmpty(entry.Text))
                {
                    return Convert.ToInt32(entry.Text);
                }
            }

            entry.Text = "0";
            return 0;
        }
    }
}
