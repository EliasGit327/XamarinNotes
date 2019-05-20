using NotesCrossPlatform.Models;
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
    public partial class MementoPage : ContentPage
    {
        String text = "";
        int id;

        public MementoPage(String str, int idIn)
        {
            InitializeComponent();

            id = idIn;
            text = str;
            editor.Text = str;
            refreshAsync();
        }

        async Task refreshAsync()
        {
            var mementos = new List<Memento>();

            List<Memento> result = await Singleton.Instance.database.QueryAsync<Memento>("select * from Memento where ParentID = ?", id);

            //var result = await Singleton.Instance.database.Table<Memento>().ToListAsync();
            foreach (var item in result)
            {
                mementos.Add(item);
            }

            mementoListView.ItemsSource = mementos.OrderByDescending(d => d.Date).ToList();
        }

        private void originalToolbarItem_Clicked(object sender, EventArgs e)
        {
            editor.Text = text;
        }

        private void MementoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            editor.Text = (e.Item as Memento).Text;
        }
    }
}