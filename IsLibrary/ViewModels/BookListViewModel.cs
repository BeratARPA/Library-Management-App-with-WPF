using Database.Classes.Repository;
using Database.Models;
using System.Collections.ObjectModel;

namespace IsLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        GenericRepository<Book> _genericRepository = new GenericRepository<Book>();
       
        public BookListViewModel()
        {
            Books = _genericRepository.GetAll();
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
