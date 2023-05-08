using IsLibrary.ViewModels;
using System;

namespace IsLibrary.Services
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        private readonly Func<Type, ViewModelBase> _viewModelBaseFactory;
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewModelBaseFactory)
        {
            _viewModelBaseFactory = viewModelBaseFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase viewModelBase = _viewModelBaseFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModelBase;
        }
    }
}
