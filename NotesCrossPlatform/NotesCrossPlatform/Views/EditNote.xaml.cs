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
    public partial class EditNote : ContentPage
    {
        Notes curNote;

        public EditNote(Notes note)
        {
            InitializeComponent();
            
            dateLabel.Text = note.Date.ToString();
            editor.Text = note.Text;

            curNote = note;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            Notes note = curNote;
            DbHelper.InsertMemento(note);

            DbHelper.UpdateNote(curNote, editor.Text);

            Navigation.PopAsync();
        }

        private void mementoButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.MementoPage(editor.Text, curNote.Id));
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Singleton.Instance.database.InsertAsync(Notes.GetCopy(curNote)).Wait();

            Navigation.PopAsync();
        }
    }
}