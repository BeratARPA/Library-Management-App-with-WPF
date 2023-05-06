using FluentValidation;
using System;
using System.ComponentModel;
using System.Linq;

namespace IsLibrary.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Validate<T>(AbstractValidator<T> validationRules, T model)
        {
            var validator = validationRules.Validate(model);
            if (!validator.IsValid)
            {
                Error = string.Join(Environment.NewLine, validator.Errors.Select(x => x.ErrorMessage));
                return false;
            }

            Error = "";
            return true;
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
    }
}
