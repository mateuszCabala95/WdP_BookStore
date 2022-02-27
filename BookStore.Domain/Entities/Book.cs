using System;

namespace BookStore.Domain.Entities
{
    public class Book: EntityBase
    {
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public Nullable<decimal> Price { get; set; }

        public Nullable<int> AuthorId { get; set; }
    }
}