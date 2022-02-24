namespace BookStore.Domain.Entities
{
    public class Book: EntityBase
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public decimal Price { get; set; }

        public int AuthorId { get; set; }
    }
}