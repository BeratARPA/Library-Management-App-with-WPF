﻿using System;
using System.Windows;

namespace IsLibrary.Helpers
{
    public class AppTheme
    {
        public static void ChangeTheme(Uri themeUri)
        {
            ResourceDictionary theme = new ResourceDictionary { Source = themeUri };

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
}
