namespace E_Commerce.Domain.Entities.Cart
{
    public class CartItem
    {
#nullable disable
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
