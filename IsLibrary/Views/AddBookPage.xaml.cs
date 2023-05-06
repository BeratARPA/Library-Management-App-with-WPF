using IsLibrary.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IsLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage : Page
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        private void txtbox_printCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = RegexHelpers.TextNotAllowed(e.Text);
        }

        private void txtbox_printCount_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            RegexHelpers.TextPasteNotAllowed(e);
        }

        private void txtbox_pageCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = RegexHelpers.TextNotAllowed(e.Text);
        }

        private void txtbox_pageCount_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            RegexHelpers.TextPasteNotAllowed(e);
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookListPage());
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookListPage());
        }
    }
}
