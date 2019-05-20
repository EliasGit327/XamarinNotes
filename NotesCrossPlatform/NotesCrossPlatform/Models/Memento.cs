using System;
using SQLite;

namespace NotesCrossPlatform.Models
{
    public class Memento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ParentID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public class Builder
        {
            private Memento result = new Memento();


            public Builder WithParentID(int ParentID)
            {
                result.ParentID = ParentID;

                return this;
            }

            public Builder WithText(string text)
            {
                result.Text = text;

                return this;
            }

            public Builder WithIsDeleted(Boolean isDeleted)
            {
                result.IsDeleted = isDeleted;

                return this;
            }

            public void Reset() => result = new Memento();

            public Memento GetResult() => result;
        }
    }
}
