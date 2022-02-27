using System.Threading.Tasks;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using BookStore.Domain.Entities;
using BookStore.UI.Dto_s;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.UI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private IBookRepository _bookRepository;

        public BookController(BookStoreDbContext context)
        {
            _bookRepository = new BookRepository(context);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result =  await _bookRepository.GetAllBooks();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSingleBook([FromRoute] int id)
        {
            var result = await _bookRepository.GetSingle(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBook([FromBody] BookDto entity)
        {
            var result = _bookRepository.AddBook(entity);
            return Created(result.Id.ToString(), result);
        }
    }
}