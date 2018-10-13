using System;
using System.Collections.Generic;
using library.Domains.Books;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BooksController : ControllerBase
    {
        private IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        } 

        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetBook")]
        [ProducesResponseType(404)]
        public ActionResult<Book> Get(Guid id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] BookDTO bookDTO)
        {
            var book = _service.Create(bookDTO);
            return CreatedAtRoute("GetBook", new { id = book.GetId() }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] BookDTO bookDTO)
        {
            var book = _service.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _service.Update(book, bookDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var book = _service.GetById(id);
            if(book == null) 
            {
                return NotFound();
            }
            _service.Delete(book);
            return NoContent();
        }
    }
}
