using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Author: EntityBase
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}