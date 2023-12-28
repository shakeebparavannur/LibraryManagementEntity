using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookService.GetBooks();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookDto book)
        {
            var response = await _bookService.AddNewBook(book);
            return Ok(response);
        }
    }
}
    