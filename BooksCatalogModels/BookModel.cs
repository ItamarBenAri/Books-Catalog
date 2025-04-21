using System.Text.RegularExpressions;

namespace BooksCatalogModels
{
    public class BookModel
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public List<string> Author { get; set; }
        public string Category { get; set; }
        public string Cover { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        private static readonly Regex Isbn10Regex = new(@"^\d{9}[\dX]$", RegexOptions.Compiled);
        private static readonly Regex Isbn13Regex = new(@"^\d{13}$", RegexOptions.Compiled);

        public BookModel()
        {
            Isbn ??= "";
            Title ??= "";
            Author ??= [];
            Category ??= "";
            Language ??= "";
            Cover ??= "";
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Isbn))
                throw new ValidationException("Missing isbn");

            if (!IsValidIsbn(Isbn))
                throw new ValidationException("Invalid ISBN format.");

            if (string.IsNullOrWhiteSpace(Category) || Category.Length < 2 || Category.Length > 50)
                throw new ValidationException("Category must be between 2 and 50 characters.");
            
            if (string.IsNullOrWhiteSpace(Language) || Language.Length < 2 || Language.Length > 20)
                throw new ValidationException("Language must be between 2 and 20 characters.");

            if (string.IsNullOrWhiteSpace(Title) || Title.Length < 2 || Title.Length > 50)
                throw new ValidationException("Title must be between 2 and 50 characters.");

            if (Author == null || Author.Count == 0 || Author.All(string.IsNullOrWhiteSpace))
                throw new ValidationException("Missing Author/s");

            int currentYear = DateTime.Now.Year;
            if (Year <= 0 || Year > currentYear)
                throw new ValidationException($"Year must be a valid number and not exceed {currentYear}.");

            if (Price <= 0 || Price > 500)
                throw new ValidationException("Price must be greater than 0 and not exceed 500.");
        }

        public static bool IsValidIsbn(string bookIsbn)
        {
            return Isbn10Regex.IsMatch(bookIsbn) || Isbn13Regex.IsMatch(bookIsbn);
        }
    }
}
