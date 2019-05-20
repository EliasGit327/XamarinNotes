using NotesCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Text;
using NotesCrossPlatform.MyClasses;

namespace NotesCrossPlatform.MyClasses
{
    class DbHelper
    {
        public static void UpdateNote(Notes note, String text)
        {
            Notes curNote = note;
            curNote.Text = text;
            curNote.Name = Adapter.getFirstLine(text);
            curNote.Date = DateTime.Now;
            Singleton.Instance.database.UpdateAsync(curNote).Wait();
        }

        public static void InsertNote(String text)
        {
            var note = new Notes.Builder()
                   .WithName(Adapter.getFirstLine(text))
                   .WithText(text)
                   .GetResult();

            Singleton.Instance.database.InsertAsync(note).Wait();
        }

        public static void InsertMemento(Notes note)
        {
            var memento = new Memento.Builder()
                   .WithParentID(note.Id)
                   .WithText(note.Text)
                   .GetResult();

            Singleton.Instance.database.InsertAsync(memento).Wait();

        }

        public static async void DeleteMementoWithID(int id)
        {
            await Singleton.Instance.database.QueryAsync<Memento>("delete from Memento where ParentID = ?", id);
        }
    }
}
