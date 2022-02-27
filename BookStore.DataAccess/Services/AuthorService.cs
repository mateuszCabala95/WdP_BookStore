using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.Services;
using BookStore.UI.Dto_s;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly BookStoreDbContext _context;
        
        public AuthorService(BookStoreDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
           await using var context = _context;
            var result = await context.Set<Author>().ToListAsync();
            
            return result;
        }

        public async Task<Author> GetSingleAsync(int id)
        {
           await using var context = _context;
            var result = await context.Set<Author>().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Author> CreateAsync(AuthorDto entity)
        {
            await using var context = _context;
            var result = context.Set<Author>().Add(new Author
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName
            });
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Author> UpdateAsync(int id, Author entity)
        {
            await using var context = _context;
            var result = await context.Set<Author>().FirstOrDefaultAsync(x => x.Id == id);
            result.Books = entity.Books ?? result.Books;
            result.FirstName = entity.FirstName ?? result.FirstName;
            result.LastName = entity.LastName ?? result.LastName;
            context.Set<Author>().Update(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var context = _context;
            var entity = context.Set<Author>().FirstOrDefault(x => x.Id == id);
            if (entity is null)
            {
                return false;
            }
            context.Set<Author>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}