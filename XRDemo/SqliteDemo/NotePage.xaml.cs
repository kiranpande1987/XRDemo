using System;
using Xamarin.Forms;

namespace XRDemo.SqliteDemo
{
    public partial class NotePage : ContentPage
    {
        public NotePage()
        {
            InitializeComponent();

            add.Clicked += OnNoteAddedClicked;
        }

        void Add_Clicked(object sender, EventArgs e)
        {
            OnNoteAddedClicked(sender, e);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}
