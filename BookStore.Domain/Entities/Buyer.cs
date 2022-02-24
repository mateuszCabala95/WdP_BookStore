namespace BookStore.Domain.Entities
{
    public class Buyer: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
    }   
}