using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Invoice: EntityBase
    {
        public Buyer Buyer { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}