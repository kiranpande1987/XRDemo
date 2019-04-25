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
            int num1 = Convert.ToInt32(edtFirstNumber.Text);
            int num2 = Convert.ToInt32(edtSecondNumber.Text);

            var result = myMathFuncs.Divide(num1, num2);

            txtResult.Text = "Result : " + result;
        }


        void BtnMultiplication_Clicked(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(edtFirstNumber.Text);
            int num2 = Convert.ToInt32(edtSecondNumber.Text);

            var result = myMathFuncs.Multiply(num1, num2);

            txtResult.Text = "Result : " + result;
        }


        void BtnSubtraction_Clicked(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(edtFirstNumber.Text);
            int num2 = Convert.ToInt32(edtSecondNumber.Text);

            var result = myMathFuncs.Subtract(num1, num2);

            txtResult.Text = "Result : " + result;
        }


        void BtnAddition_Clicked(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(edtFirstNumber.Text);
            int num2 = Convert.ToInt32(edtSecondNumber.Text);

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
            base.OnAppearing();
            myMathFuncs.Dispose();
        }
    }
}
