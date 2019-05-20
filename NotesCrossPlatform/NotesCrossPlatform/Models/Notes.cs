using System;
using SQLite;

namespace NotesCrossPlatform.Models
{
    public class Notes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public class Builder
        {
            private Notes result = new Notes();

            public Builder WithName(string name)
            {
                result.Name = name;

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

            public void Reset() => result = new Notes();

            public Notes GetResult() => result;

        }

        public static Notes GetCopy(Notes original)
        {
            return new Notes.Builder().WithName(original.Name).WithText(original.Text).GetResult();
        }
    }
}

