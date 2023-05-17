using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsLibrary.ViewModels
{
    public class ErrorReportViewModel : ViewModelBase
    {
        public IEnumerable<Exception> Exceptions { get; }

        public ErrorReportViewModel(IEnumerable<Exception> exceptions)
        {
            Exceptions = exceptions;

            ErrorMessage = exceptions.Select(x => x.Message).FirstOrDefault();
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private string _userMessage;
        public string UserMessage
        {
            get { return _userMessage; }
            set
            {
                _userMessage = value;
                OnPropertyChanged(nameof(UserMessage));
            }
        }
    }
}
