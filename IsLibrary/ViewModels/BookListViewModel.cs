using Database.Classes.Repository;
using Database.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IsLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        GenericRepository<Book> _genericRepository = new GenericRepository<Book>();
        public ObservableCollection<Book> Books { get; private set; }

        public BookListViewModel()
        {
            Books = _genericRepository.GetAll();
        }

        public async Task<ObservableCollection<Book>> FillBook()
        {
            return await _genericRepository.GetAllAsync();
        }
    }
}
