using E_Commerce.Domain.Entities.Cart;

namespace E_Commerce.Presistence.Repositories
{
    public interface ICartRepository
    {
        //Delete//Update//GetById
        Task<bool> DeleteAsync(string Id);

        Task<CustomerCart> UpdateAndCreateAsync(CustomerCart customerCart, TimeSpan? Ttl = null);
        Task<CustomerCart> GetCartByIdAsync(string Id);
    }
}
