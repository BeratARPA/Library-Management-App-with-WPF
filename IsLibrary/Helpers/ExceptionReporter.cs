using IsLibrary.ViewModels;
using IsLibrary.Views;
using System;
using System.Windows;

namespace IsLibrary.Helpers
{
    public static class ExceptionReporter
    {
        public static void Show(params Exception[] exceptions)
        {
            if (exceptions == null) return;

            try
            {
                ErrorReportViewModel errorReportViewModel = new ErrorReportViewModel(exceptions);
                ErrorReportView errorReportView = new ErrorReportView() { DataContext = errorReportViewModel };
                errorReportView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
