using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DataAccess.Services;
using BookStore.Domain.Entities;
using BookStore.UI.Dto_s;

namespace BookStore.DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetSingleAuthorAsync(int id);

        Task<Author> CreateAuthorAsync(AuthorDto dto);

        Task<Author> UpdateAuthorAsync(int id, Author entity);

        Task<bool> DeleteAuthorAsync(int id);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private AuthorService _authorService;

        public AuthorRepository(BookStoreDbContext context)
        {
            _authorService = new AuthorService(context);
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return _authorService.GetAllAsync();
        }

        public Task<Author> GetSingleAuthorAsync(int id)
        {
            return _authorService.GetSingleAsync(id);
        }

        public Task<Author> CreateAuthorAsync(AuthorDto dto)
        {
            return _authorService.CreateAsync(dto);
        }

        public Task<Author> UpdateAuthorAsync(int id, Author entity)
        {
            return _authorService.UpdateAsync(id, entity);
        }

        public Task<bool> DeleteAuthorAsync(int id)
        {
            return _authorService.DeleteAsync(id);
        }
    }
}