using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

namespace Presentation.controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public BooksController(IServiceManager context)
        {
            _serviceManager = context;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _serviceManager.BookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _serviceManager.BookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            _serviceManager.BookService.AddBook(book);
            return StatusCode(201, book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            _serviceManager.BookService.UpdateBook(id, book);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _serviceManager.BookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            _serviceManager.BookService.DeleteBook(id);
            return NoContent();
        }
    }
}
