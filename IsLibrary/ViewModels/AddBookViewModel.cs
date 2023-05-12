using Database.Classes.Repository;
using Database.Models;
using IsLibrary.Commands;
using IsLibrary.Services;
using IsLibrary.ValidationRules;
using System;
using System.Windows.Input;

namespace IsLibrary.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        GenericRepository<Book> _genericRepository = new GenericRepository<Book>();
        public RelayCommand AddBookCommand { get; private set; }

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

        public RelayCommand NavigateToBooksCommand { get; set; }

        public AddBookViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AddBookCommand = new RelayCommand(x => AddBook(), x => Validate(new AddBookValidation(), this));
            NavigateToBooksCommand = new RelayCommand(x => _navigationService.NavigateTo<BookListViewModel>());
        }

        public void Clear()
        {
            Name = string.Empty;
            Category = string.Empty;
            Subject = string.Empty;
            PrintingPlace = string.Empty;
            PrintCount = 0;
            PrintDate = DateTime.Now;
            SupplyCategory = string.Empty;
            SupplyDate = DateTime.Now;
            PageCount = 0;
            Image = string.Empty;
            Barcode = string.Empty;
        }

        public void AddBook()
        {
            Book book = new Book
            {
                Name = Name,
                Category = Category,
                Subject = Subject,
                PrintingPlace = PrintingPlace,
                PrintCount = PrintCount,
                PrintDate = PrintDate,
                SupplyCategory = SupplyCategory,
                SupplyDate = SupplyDate,
                PageCount = PageCount,
                Image = Image,
                Barcode = Barcode,
                RelicStatus = RelicStatus,
                PublishingHouseId = 1,
                WriterId = 1
            };

            _genericRepository.Add(book);
            //Clear();
            _navigationService.NavigateTo<BookListViewModel>();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        private string _printingPlace;
        public string PrintingPlace
        {
            get { return _printingPlace; }
            set
            {
                _printingPlace = value;
                OnPropertyChanged(nameof(PrintingPlace));
            }
        }

        private int _printCount;
        public int PrintCount
        {
            get { return _printCount; }
            set
            {
                _printCount = value;
                OnPropertyChanged(nameof(PrintCount));
            }
        }

        private DateTime _printDate = DateTime.Now;
        public DateTime PrintDate
        {
            get { return _printDate; }
            set
            {
                _printDate = value;
                OnPropertyChanged(nameof(PrintDate));
            }
        }

        private string _supplyCategory;
        public string SupplyCategory
        {
            get { return _supplyCategory; }
            set
            {
                _supplyCategory = value;
                OnPropertyChanged(nameof(SupplyCategory));
            }
        }

        private DateTime _supplyDate = DateTime.Now;
        public DateTime SupplyDate
        {
            get { return _supplyDate; }
            set
            {
                _supplyDate = value;
                OnPropertyChanged(nameof(SupplyDate));
            }
        }

        private int _pageCount;
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                OnPropertyChanged(nameof(PageCount));
            }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged(nameof(Barcode));
            }
        }

        private bool _relicStatus = true;
        public bool RelicStatus
        {
            get { return _relicStatus; }
            set
            {
                _relicStatus = value;
                OnPropertyChanged(nameof(RelicStatus));
            }
        }
    }
}
