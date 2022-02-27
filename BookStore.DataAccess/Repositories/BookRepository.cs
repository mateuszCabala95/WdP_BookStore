using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DataAccess.Services;
using BookStore.Domain.Entities;
using BookStore.Domain.Services;
using BookStore.UI.Dto_s;

namespace BookStore.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetSingle(int id);

        Task<Book> AddBook(BookDto entity);
    }

    public class BookRepository : IBookRepository
    {
        private IBookService _bookService;
        public BookRepository(BookStoreDbContext context)
        {
            _bookService = new BookService(context);
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            return _bookService.GetAllAsync();
        }

        public Task<Book> GetSingle(int id)
        {
            return _bookService.GetSingleAsync(id);
        }

        public Task<Book> AddBook(BookDto entity)
        {
            return _bookService.CreateAsync(entity);
        }
    }
}