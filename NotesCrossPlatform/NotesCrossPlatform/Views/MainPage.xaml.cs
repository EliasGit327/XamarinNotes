using NotesCrossPlatform.Models;
using NotesCrossPlatform.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesCrossPlatform.MyClasses;
using Xamarin.Forms;

namespace NotesCrossPlatform
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            

        }

        protected override void OnAppearing()
        {  
            base.OnAppearing();
            
            refreshAsync();
        }

        async Task refreshAsync()
        {
            var notes = new List<Notes>();

            var result = await Singleton.Instance.database.Table<Notes>().ToListAsync();
            foreach (var item in result)
            {
                notes.Add(item);
            }

            listView.ItemsSource = notes.OrderByDescending(d => d.Date).ToList();
        }

        private void ToolbarItem_Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.NewNote());
        }

        private void ToolbarItem_Settings(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Settings());
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new EditNote(e.Item as Notes));
        }

        private void ContextAction_OnDeleteTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new EditNote(e.Item as Notes));
        }

        private void deleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = (Notes) (sender as Xamarin.Forms.MenuItem).BindingContext;
            Singleton.Instance.database.DeleteAsync(mi).Wait();

            DbHelper.DeleteMementoWithID(mi.Id);

            refreshAsync();
        }

    }
}
