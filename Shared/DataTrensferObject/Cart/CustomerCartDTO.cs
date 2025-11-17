namespace E_Commerce.Shared.DataTrensferObject.Cart;
public class CustomerCartDTO
{

    public string Id { get; set; }
    public ICollection<CartItemDTO> CartItems { get; set; } = [];
}
