using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class BookStoreDbContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {
            
        }
    }
}