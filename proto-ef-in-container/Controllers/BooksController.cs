using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proto_ef_in_container.Managers;
using proto_ef_in_container.Model;

namespace proto_ef_in_container.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksManager booksManager;

        public BooksController(BooksManager booksManager)
        {
            this.booksManager = booksManager;
        }

        // GET api/books
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Book> books = await booksManager.GetBooks();
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Book book = await booksManager.GetBookByISDN(id);
            
            if (book == null)
            {
                return NotFound($"Book for ISDN {id} not found.");
            }

            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (await booksManager.DoesBookExist(book))
            {
                return Conflict();
            }

            Book newBook = await booksManager.AddBook(book);
            return Ok(newBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return BadRequest();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return BadRequest();
        }
    }
}
