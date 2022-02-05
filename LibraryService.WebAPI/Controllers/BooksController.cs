using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using System.Collections.Generic;

namespace LibraryService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookrepository;

        public BooksController(IBooksService bookrepository)
        {
            this._bookrepository = bookrepository;
        }

        [HttpGet("{libraryId, ids}")]
        public IActionResult GetBooks(int libraryId, int[] ids)
        {
            var getbooks = _bookrepository.Get(libraryId, ids);
            if (getbooks == null)
            {
                return NotFound();
            }

            return Ok(getbooks);
        }

        [HttpPost("{book}")]
        public async Task<ActionResult<Book>> AddBooks([FromBody] Book book)
        {
            var newBook = await _bookrepository.Add(book);
            return CreatedAtAction(nameof(GetBooks), new { Id = newBook.Id }, newBook);
        }
    }
}