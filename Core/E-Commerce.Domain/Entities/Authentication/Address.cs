namespace E_Commerce.Domain.Entities.Authentication
{
    public class Address
    {
        public AppUser User { get; set; }
        public string UserId { get; set; } //Fk-UQ
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}
