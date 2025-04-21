using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using BooksCatalogModels;

namespace BooksCatalogDal
{
    public class DalService
    {
        private readonly IConfiguration _config;

        public DalService(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<BookModel> ExtractAllBooks(XDocument doc)
        {
            var books = new List<BookModel>();

            foreach (var book in doc.Descendants("book"))
            {
                books.Add(ExtractOneBook(book));
            }

            return books;
        }

        public BookModel ExtractOneBook(XElement book)
        {
            string isbn = book.Element("isbn")?.Value ?? "N/A";
            string title = book.Element("title")?.Value ?? "N/A";
            string cover = book.Attribute("cover")?.Value ?? "N/A";
            List<string> authors = [.. book.Elements("author").Select(a => a.Value)];
            string category = book.Attribute("category")?.Value ?? "N/A";
            string language = book.Element("title")?.Attribute("lang")?.Value ?? "N/A";
            int year = int.TryParse(book.Element("year")?.Value, out var parsedYear) ? parsedYear : -1;
            decimal price = decimal.TryParse(book.Element("price")?.Value, out var parsedPrice) ? parsedPrice : -1;

            return new BookModel
            {
                Isbn = isbn,
                Title = title,
                Cover = cover,
                Author = authors,
                Category = category,
                Language = language,
                Year = year,
                Price = price
            };
        }

        public XDocument LoadFile()
        {
            string fullPath = GetFilePath();
            return XDocument.Load(fullPath);
        }

        public bool AddBookToFile(BookModel book)
        {
            XDocument doc = LoadFile();
            XElement newBook = GenerateBookElement(book);

            doc.Root?.Add(newBook);
            doc.Save(GetFilePath());

            return true;
        }

        public bool EditBookInFile(BookModel book)
        {
            DeleteBookFromFile(book.Isbn);

            XDocument doc = LoadFile();
            XElement updatedBook = GenerateBookElement(book);

            doc.Root?.Add(updatedBook);
            doc.Save(GetFilePath());

            return true;
        }

        public bool DeleteBookFromFile(string bookIsbn)
        {
            XDocument doc = LoadFile();

            var existingBook = doc.Descendants("book")
                .FirstOrDefault(b => b.Element("isbn")?.Value == bookIsbn);

            if (existingBook == null)
                throw new Exception("Book not exit.");

            existingBook.Remove();
            doc.Save(GetFilePath());

            return true;
        }

        private string GetFilePath()
        {
            var relativePath = _config["AppSettings:BooksFilePath"];
            if (string.IsNullOrWhiteSpace(relativePath))
                throw new InvalidOperationException("BooksFilePath is not configured in appsettings.json.");

            return Path.Combine(Directory.GetCurrentDirectory(), relativePath);
        }

        private XElement GenerateBookElement(BookModel book)
        {
            var bookElement = new XElement("book",
                new XAttribute("category", book.Category),
                string.IsNullOrWhiteSpace(book.Cover) ? null : new XAttribute("cover", book.Cover),
                new XElement("isbn", book.Isbn),
                CreateTitleElement(book.Title, book.Language),
                book.Author
                    .Where(a => !string.IsNullOrWhiteSpace(a))
                    .Select(a => new XElement("author", a)),
                new XElement("year", book.Year),
                new XElement("price", book.Price)
            );

            return bookElement;
        }

        private XElement CreateTitleElement(string title, string? lang)
        {
            var titleElement = new XElement("title", title);
            if (!string.IsNullOrWhiteSpace(lang))
                titleElement.Add(new XAttribute("lang", lang));
            return titleElement;
        }
    }
}
