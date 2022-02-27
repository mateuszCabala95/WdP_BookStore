using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.UI.Dto_s;

namespace BookStore.Domain.Services
{
    public interface IAuthorService: IServiceBase<Author>
    {
        Task<Author> CreateAsync(AuthorDto entity);
    }
}