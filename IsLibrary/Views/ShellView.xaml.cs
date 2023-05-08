using IsLibrary.Helpers;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace IsLibrary.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            AppTheme.ChangeTheme(new Uri(Properties.Settings.Default.Theme, UriKind.Relative));
            AppLanguage.ChangeLanguage(new Uri(Properties.Settings.Default.Language, UriKind.Relative));
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        #region Window
        private void tglBtn_collapsible_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)tglBtn_collapsible.IsChecked)
            {
                grdColumn0.Width = new GridLength(200, GridUnitType.Pixel);

                txtBlk_applicationName.Visibility = Visibility.Visible;
                txtBlk_books.Visibility = Visibility.Visible;
                txtBlk_readers.Visibility = Visibility.Visible;
                txtBlk_relics.Visibility = Visibility.Visible;
                txtBlk_expiredBooks.Visibility = Visibility.Visible;
                txtBlk_settings.Visibility = Visibility.Visible;
                txtBlk_about.Visibility = Visibility.Visible;

                brd_version.Visibility = Visibility.Visible;

                pth_addBook.Width = 100;
                pth_addBook.Height = 100;
            }
            else
            {
                grdColumn0.Width = new GridLength(80, GridUnitType.Pixel);

                txtBlk_applicationName.Visibility = Visibility.Collapsed;
                txtBlk_books.Visibility = Visibility.Collapsed;
                txtBlk_readers.Visibility = Visibility.Collapsed;
                txtBlk_relics.Visibility = Visibility.Collapsed;
                txtBlk_expiredBooks.Visibility = Visibility.Collapsed;
                txtBlk_settings.Visibility = Visibility.Collapsed;
                txtBlk_about.Visibility = Visibility.Collapsed;

                brd_version.Visibility = Visibility.Collapsed;

                pth_addBook.Width = 50;
                pth_addBook.Height = 50;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void WindowBorder(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void cmbItem_defaultTheme_Selected(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Views/Themes/Default.xaml", UriKind.Relative));
            Properties.Settings.Default.Theme = "Views/Themes/Default.xaml";
            Properties.Settings.Default.Save();
        }

        private void cmbItem_darkTheme_Selected(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Views/Themes/Dark.xaml", UriKind.Relative));
            Properties.Settings.Default.Theme = "Views/Themes/Dark.xaml";
            Properties.Settings.Default.Save();
        }

        private void cmbItem_lightTheme_Selected(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Views/Themes/Light.xaml", UriKind.Relative));
            Properties.Settings.Default.Theme = "Views/Themes/Light.xaml";
            Properties.Settings.Default.Save();
        }

        private void cmbItem_englishLanguage_Selected(object sender, RoutedEventArgs e)
        {
            AppLanguage.ChangeLanguage(new Uri("Views/Languages/StringResources.en-US.xaml", UriKind.Relative));
            Properties.Settings.Default.Language = "Views/Languages/StringResources.en-US.xaml";
            Properties.Settings.Default.Save();
        }

        private void cmbItem_turkishLanguage_Selected(object sender, RoutedEventArgs e)
        {
            AppLanguage.ChangeLanguage(new Uri("Views/Languages/StringResources.tr-TR.xaml", UriKind.Relative));
            Properties.Settings.Default.Language = "Views/Languages/StringResources.tr-TR.xaml";
            Properties.Settings.Default.Save();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_maximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Menu
        private void btn_books_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenu(0);

            txtBlk_route.Text = txtBlk_books.Text;
        }

        private void btn_readers_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenu(1);

            txtBlk_route.Text = txtBlk_readers.Text;
        }

        private void btn_relics_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenu(2);

            txtBlk_route.Text = txtBlk_relics.Text;
        }

        private void btn_expiredBooks_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenu(3);

            txtBlk_route.Text = txtBlk_expiredBooks.Text;
        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenu(4);

            txtBlk_route.Text = txtBlk_settings.Text;
        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenu(5);

            txtBlk_route.Text = txtBlk_about.Text;
        }

        public void SelectedMenu(int index)
        {
            btn_books.IsChecked = false;
            btn_readers.IsChecked = false;
            btn_relics.IsChecked = false;
            btn_expiredBooks.IsChecked = false;
            btn_settings.IsChecked = false;
            btn_about.IsChecked = false;

            switch (index)
            {
                case 0:
                    btn_books.IsChecked = true;
                    break;
                case 1:
                    btn_readers.IsChecked = true;
                    break;
                case 2:
                    btn_relics.IsChecked = true;
                    break;
                case 3:
                    btn_expiredBooks.IsChecked = true;
                    break;
                case 4:
                    btn_settings.IsChecked = true;
                    break;
                case 5:
                    btn_about.IsChecked = true;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
