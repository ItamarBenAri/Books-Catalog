using System.Xml.Linq;
using BooksCatalogModels;

namespace BooksCatalogDal
{
    public class Dal
    {
        private readonly DalService _dalService;

        public Dal(DalService dalService)
        {
            _dalService = dalService;
        }

        public IEnumerable<BookModel> LoadAllBooksFromFile<T>()
        {
            XDocument doc = _dalService.LoadFile();
            return (IEnumerable<BookModel>)_dalService.ExtractAllBooks(doc);
        }

        public BookModel? LoadOneBookFromFile<T>(string isbn)
        {
            XDocument doc = _dalService.LoadFile();
            XElement? book = doc.Descendants("book")
                .FirstOrDefault(b => b.Element("isbn")?.Value == isbn);
            if (book == null)
            {
                return null;
            }
            return _dalService.ExtractOneBook(book);
        }

        public bool AddBookToFile<T>(BookModel book)
        {
            return _dalService.AddBookToFile(book);

        }

        public bool EditBookInFile<T>(BookModel book)
        {
            return _dalService.EditBookInFile(book);
        }

        public bool DeleteBookFromFile<T>(string bookIsbn)
        {
            return _dalService.DeleteBookFromFile(bookIsbn);
        }
    }
}
