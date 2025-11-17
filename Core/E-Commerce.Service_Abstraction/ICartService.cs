using E_Commerce.Shared.DataTrensferObject.Cart;

namespace E_Commerce.Service_Abstraction
{
    public interface ICartService
    {
        Task<CustomerCartDTO> UpdateAndCreateAsync(CustomerCartDTO customerCartDTO);
        Task<CustomerCartDTO> GetByIdAsync(string Id);
        Task DeleteCartAsync(string Id);
    }
}
