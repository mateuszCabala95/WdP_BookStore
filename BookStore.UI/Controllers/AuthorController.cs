using System.Threading.Tasks;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using BookStore.UI.Dto_s;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.UI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController: ControllerBase
    {
        private AuthorRepository _authorRepository;

        public AuthorController(BookStoreDbContext context)
        {
            _authorRepository = new AuthorRepository(context);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto dto)
        {
            var result = await _authorRepository.CreateAuthorAsync(dto);
            return Created(result.Id.ToString(), result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _authorRepository.GetAllAuthorsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSIngle([FromRoute] int id)
        {
            var result = await _authorRepository.GetSingleAuthorAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}