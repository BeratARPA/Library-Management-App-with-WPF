using IsLibrary.Helpers;
using IsLibrary.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IsLibrary.Views
{
    /// <summary>
    /// Interaction logic for AddBookUserControl.xaml
    /// </summary>
    public partial class AddBookUserControl : UserControl
    {
        public AddBookUserControl()
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
    }
}
