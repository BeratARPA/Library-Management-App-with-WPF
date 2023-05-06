using IsLibrary.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace IsLibrary.Views
{
    /// <summary>
    /// Interaction logic for BookListPage.xaml
    /// </summary>
    public partial class BookListPage : Page
    {
        public BookListPage()
        {
            InitializeComponent();
        }

        private void btn_addBook_Click(object sender, RoutedEventArgs e)
        {
            frm_main.Content = new AddBookPage();
        }
    }
}
