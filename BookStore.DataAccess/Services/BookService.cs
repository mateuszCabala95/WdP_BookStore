using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Services
{
    public class BookService: IBookService
    {
        private readonly BookStoreDbContext _context;
        
        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            await using var context = _context;
            var result = await context.Set<Book>().ToListAsync();
            
            return result;        }

        public async Task<Book> GetSingleAsync(int id)
        {
            await using var context = _context;
            var result = await context.Set<Book>().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            await using var context = _context;
            var result = context.Set<Book>().Add(entity);
            await context.SaveChangesAsync();
            return result.Entity;        
        }

        public async Task<Book> UpdateAsync(int id, Book entity)
        {
            await using var context = _context;
            var result = await context.Set<Book>().FirstOrDefaultAsync(x => x.Id == id);
            result.Author = entity.Author ?? result.Author;
            result.Price = entity.Price ?? result.Price;
            result.Title = entity.Title ?? result.Title;
            result.AuthorId = entity.AuthorId ?? result.AuthorId;
            context.Set<Book>().Update(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var context = _context;
            var entity = context.Set<Book>().FirstOrDefault(x => x.Id == id);
            if (entity is null)
            {
                return false;
            }
            context.Set<Book>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}