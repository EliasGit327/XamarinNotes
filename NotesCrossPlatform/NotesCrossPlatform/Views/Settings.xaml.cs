using NotesCrossPlatform.Models;
using NotesCrossPlatform.MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesCrossPlatform.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private async void dropButton_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("John Cena", "Are you sure about that?", "Yes", "No");
            if (answer == true)
            {
                Singleton.Instance.database.DeleteAllAsync<Notes>().Wait();
                Singleton.Instance.database.DeleteAllAsync<Memento>().Wait();
            }

        }

        private async void createButton_Clicked(object sender, EventArgs e)
        {
            var note = new Notes.Builder()
                .WithName("hello")
                .WithText("hello\nworld")
                .GetResult();

            Singleton.Instance.database.InsertAsync(note).Wait();

            var result = await Singleton.Instance.database.Table<Notes>().ToListAsync();

            note.Text = "first";
            DbHelper.InsertMemento(note);
            note.Text = "second";
            DbHelper.InsertMemento(note);
            note.Text = "third";
            DbHelper.InsertMemento(note);

        }

        private void rateUsButton_OnClicked(object sender, EventArgs e)
        {
            Abstraction abstraction = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:

                    abstraction = new Abstraction(new Platform_iOS());
                    break;

                case Device.Android:

                    abstraction = new Abstraction(new PlatformAndroid());
                    break;
            }

            DisplayAlert("Rate us!", abstraction.Operation(), "OK");
        }
    }
}