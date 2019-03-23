using System;
using Xamarin.Forms;

namespace XRDemo.SqliteDemo
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopModalAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopModalAsync();
        }
    }
}
