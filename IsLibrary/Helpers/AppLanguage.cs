using System;
using System.Windows;

namespace IsLibrary.Helpers
{
    public class AppLanguage
    {
        public static void ChangeLanguage(Uri languageUri)
        {      
            ResourceDictionary theme = new ResourceDictionary { Source = languageUri };

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(theme);           
        }
    }
}
