using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.UI.Dto_s;

namespace BookStore.Domain.Services
{
    public interface IBookService: IServiceBase<Book>
    {
        public Task<Book> CreateAsync(BookDto entity);
    }
}