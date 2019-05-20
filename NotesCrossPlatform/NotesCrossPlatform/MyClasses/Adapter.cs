using System;
using System.Collections.Generic;
using System.Text;

namespace NotesCrossPlatform.Models
{
    class Adapter
    {
        public static String getFirstLine(String text)
        {
            var name = "";
            if (text.Contains("\n"))
            {
                string[] splitString = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                name = splitString[0];
            }
            else
            {
                name = text;
            }

            return name;             
        }

    }
}
