using BooksCatalogBackend.Src.Services;
using BooksCatalogModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalogBackend.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public ActionResult<IEnumerable<BookModel>> GetAllBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("GetOneBook/{bookIsbn}")]
        public ActionResult<BookModel> GetOneBook(string bookIsbn)
        {
            return Ok(_bookService.GetOneBook(bookIsbn));
        }

        [HttpPost("AddBook")]
        public ActionResult AddBook(BookModel book)
        {
            _bookService.AddBook(book);
            return Created();
        }

        [HttpPut("EditBook")]
        public ActionResult EditBook(BookModel book)
        {
            _bookService.EditBook(book);
            return Ok();
        }

        [HttpDelete("DeleteBook/{bookIsbn}")]
        public ActionResult DeleteBook(string bookIsbn)
        {
            _bookService.DeleteBook(bookIsbn);
            return NoContent();
        }
    }
}