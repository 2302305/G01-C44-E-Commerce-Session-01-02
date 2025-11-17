namespace E_Commerce.Domain.Entities.Cart
{
    public class CustomerCart
    {
#nullable disable
        public string Id { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
