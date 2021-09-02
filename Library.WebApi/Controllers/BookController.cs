using Library.Services.Attributes;
using Library.Services.Models;
using Library.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        [HttpGet("bygenre")]
        public IActionResult GetByGenre(string genre) =>
            Ok(_bookServices.GetByGenre(genre));

        [HttpGet]
        public IActionResult Get() =>
            Ok(_bookServices.GetBooks());

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _bookServices.AddBook(book);
            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            return Ok(_bookServices.GetBook(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            _bookServices.DeleteBook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book) =>
            Ok(_bookServices.UpdateBook(book));
    }
}
