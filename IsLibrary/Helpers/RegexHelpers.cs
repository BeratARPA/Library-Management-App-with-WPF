using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace IsLibrary.Helpers
{
    public class RegexHelpers
    {
        private static Regex _regex;
        public static bool TextNotAllowed(string text)
        {
            _regex = new Regex("[^0-9]+");
            return _regex.IsMatch(text);
        }

        public static void TextPasteNotAllowed(DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (TextNotAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
