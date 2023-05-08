using Database.Classes.Repository;
using Database.Models;
using IsLibrary.Commands;
using IsLibrary.Services;
using System.Collections.ObjectModel;

namespace IsLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        GenericRepository<Book> _genericRepository = new GenericRepository<Book>();

        private ObservableCollection<Book> _books;

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }


        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged(nameof(NavigationService));
            }
        }

        public RelayCommand NavigateToAddBookCommand { get; set; }

        public BookListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToAddBookCommand = new RelayCommand(x => _navigationService.NavigateTo<AddBookViewModel>());
            Books = _genericRepository.GetAll();
        }
    }
}
