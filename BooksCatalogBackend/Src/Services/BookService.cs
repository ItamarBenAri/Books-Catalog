
using BooksCatalogDal;
using BooksCatalogModels;

namespace BooksCatalogBackend.Src.Services
{
    public class BookService
    {
        private readonly Dal _dal;

        public BookService(Dal dal)
        {
            _dal = dal;
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            IEnumerable<BookModel> books = _dal.LoadAllBooksFromFile<BookModel>();
            return books;
        }

        public BookModel? GetOneBook(string bookIsbn)
        {
            if (!BookModel.IsValidIsbn(bookIsbn))
            {
                throw new ValidationException("Invalid ISBN format.");
            }
            BookModel? book = _dal.LoadOneBookFromFile<BookModel>(bookIsbn);
            if (book == null)
            {
                throw new ResourceNotFoundException(bookIsbn);
            }
            return book;
        }

        public bool AddBook(BookModel book)
        {
            book.Validate();
            if (IsBookExist(book.Isbn)) throw new ValidationException("Book already exist.");
            return _dal.AddBookToFile<bool>(book);
        }

        public bool EditBook(BookModel book)
        {
            book.Validate();
            if (!IsBookExist(book.Isbn)) throw new ResourceNotFoundException(book.Isbn);
            return _dal.EditBookInFile<bool>(book);
        }

        public bool DeleteBook(string bookIsbn)
        {
            if (!BookModel.IsValidIsbn(bookIsbn))
            {
                throw new ValidationException("Invalid ISBN format.");
            }
            if (!IsBookExist(bookIsbn)) throw new ResourceNotFoundException(bookIsbn);
            return _dal.DeleteBookFromFile<bool>(bookIsbn);
        }

        private bool IsBookExist(string bookIsbn)
        {
            return _dal.LoadOneBookFromFile<BookModel>(bookIsbn) != null;
        }
    }
}
