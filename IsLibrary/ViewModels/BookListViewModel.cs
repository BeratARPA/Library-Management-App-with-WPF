using Database.Classes.Repository;
using Database.Models;
using IsLibrary.Commands;
using IsLibrary.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace IsLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        GenericRepository<Book> _genericRepository = new GenericRepository<Book>();
        public RelayCommand DeleteBookCommand { get; private set; }

        public BookListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToAddBookCommand = new RelayCommand(x => AddBook());
            DeleteBookCommand = new RelayCommand(DeleteBook);
            Books = _genericRepository.GetAll();
        }

        public void AddBook()
        {
            _navigationService.NavigateTo<AddBookViewModel>();
            Error = null;
        }
 
        public void DeleteBook(object parameter)
        {
            if (parameter is null)
            {
                ResourceDictionary language = new ResourceDictionary { Source = new Uri(Properties.Settings.Default.Language, UriKind.Relative) };
                Error = language["SelectTheDataYouWantToDelete"].ToString();
                return;
            }

            Book book = (Book)parameter;
            _genericRepository.Delete(_genericRepository.GetById(book.BookId));
            Books.Remove(book);
        }

        public RelayCommand NavigateToAddBookCommand { get; set; }
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
    }
}
