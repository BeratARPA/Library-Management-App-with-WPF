using System.Windows;

namespace IsLibrary.Views
{
    /// <summary>
    /// Interaction logic for ErrorReportView.xaml
    /// </summary>
    public partial class ErrorReportView : Window
    {
        public ErrorReportView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
