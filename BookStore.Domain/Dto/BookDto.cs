using System;

namespace BookStore.UI.Dto_s
{
    public class BookDto
    {
        public string Title { get; set; }
        
        public Nullable<decimal> Price { get; set; }

        public int AuthorId { get; set; }
    }
}