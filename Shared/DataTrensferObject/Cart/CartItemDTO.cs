namespace E_Commerce.Shared.DataTrensferObject.Cart;

public class CartItemDTO
{
#nullable disable
    public string Id { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}