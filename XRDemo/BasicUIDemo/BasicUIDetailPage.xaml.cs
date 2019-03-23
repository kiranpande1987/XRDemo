using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;
using System;

namespace XRDemo.BasicUIDemo
{
    public partial class BasicUIDetailPage : ContentPage
    {
        public BasicUIDetailPage()
        {
            InitializeComponent();
            init();
            setListener();
        }

        private void init()
        {
            showListView();
        }

        public void setListener()
        {
            btnAdd.Clicked += BtnAdd_ClickedAsync;
            btnLoadList.Clicked += BtnLoadList_Clicked;
            btnLoadGrid.Clicked += BtnLoadGrid_Clicked;
        }

        void BtnLoadList_Clicked(object sender, EventArgs e)
        {
            showListView();
        }

        void BtnLoadGrid_Clicked(object sender, EventArgs e)
        {
            showGridView();
        }

        async void BtnAdd_ClickedAsync(object sender, System.EventArgs e)
        {
            string item = edtText.Text;

            if (string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                return;

            var answer = await DisplayAlert("Add?", $"{item}", "Confirm", "Cancel");

            if (answer)
            {
                addToPreferences(item);

                if (listView.IsVisible)
                    showListView();
                else
                    showGridView();

                edtText.Text = "";
            }
        }

        public void addToPreferences(string item)
        {
            string arrays = Preferences.Get("items", "");

            if (string.IsNullOrEmpty(arrays))
                arrays = item;
            else
                arrays = arrays + "@" + item;

            Preferences.Set("items", arrays);
        }

        public string[] getListOfItems()
        {
            List<string> items = new List<string>();

            string arrays = Preferences.Get("items", "");

            if (string.IsNullOrEmpty(arrays))
            {
                return new string[] { };
            }

            string[] arr = arrays.Split('@');

            Array.Reverse(arr);

            return arr;
        }

        public void showListView()
        {
            listView.IsVisible = true;
            gridView.IsVisible = false;
            listView.ItemsSource = getListOfItems();
        }

        public void showGridView()
        {
            listView.IsVisible = false;
            gridView.IsVisible = true;

            gridView.ColumnDefinitions.Clear();
            gridView.RowDefinitions.Clear();

            gridView.Children.Clear();

            gridView.RowDefinitions.Add(new RowDefinition());
            gridView.RowDefinitions.Add(new RowDefinition());
            gridView.ColumnDefinitions.Add(new ColumnDefinition());
            gridView.ColumnDefinitions.Add(new ColumnDefinition());
            gridView.ColumnDefinitions.Add(new ColumnDefinition());

            string[] list = getListOfItems();

            int rows = (list.Length / 3);

            var productIndex = 0;
            for (int rowIndex = 0; rowIndex < rows + 1; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    if (productIndex >= list.Length)
                    {
                        break;
                    }
                    var product = list[productIndex];
                    productIndex += 1;
                    var label = new Label
                    {
                        Text = product,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridView.Children.Add(label, columnIndex, rowIndex);
                }
            }
        }
    }
}
