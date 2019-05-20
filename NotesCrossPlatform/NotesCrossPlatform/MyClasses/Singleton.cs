using SQLite;
using System;
using System.IO;
using  NotesCrossPlatform.MyClasses;

namespace NotesCrossPlatform.Models
{
    public sealed class Singleton
    { 
        static Singleton() { }

        private Singleton()
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Notes>().Wait();
            database.CreateTableAsync<Memento>().Wait();

        }

        public static Singleton Instance { get; } = new Singleton();

        //_________________________________________________________

        string databasePath;
        public SQLiteAsyncConnection database;


    }
}
