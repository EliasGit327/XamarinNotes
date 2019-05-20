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
    public partial class NewNote : ContentPage
    {
        public NewNote()
        {
            InitializeComponent();
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            DbHelper.InsertNote(editor.Text);

            Navigation.PopAsync();
        }
    }
}