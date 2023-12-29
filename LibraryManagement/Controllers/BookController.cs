using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("getallbooks")]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookService.GetBooks();
            return Ok(response);
        }
        [HttpPost("add-new-book")]
        public async Task<IActionResult> AddNewBook(BookDto book)
        {
            var response = await _bookService.AddNewBook(book);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await _bookService.GetBookById(id);
            return Ok(response);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetBookByName(string name)
        {
            var response = await _bookService.GetBookByName(name);
            return Ok(response);
        }
        [HttpPut("udpatebook")]
        public async Task<IActionResult> UpdateBook(int id,BookDto book)
        {
            var response = await _bookService.UpdateBook(id,book);
            return Ok(response);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = _bookService.DeleteBook(id);
            return Ok(response);
        }

    }
}
    