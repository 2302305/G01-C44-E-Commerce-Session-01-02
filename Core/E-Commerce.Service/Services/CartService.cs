using E_Commerce.Domain.Entities.Cart;
using E_Commerce.Presistence.Repositories;
using E_Commerce.Shared.DataTrensferObject.Cart;

namespace E_Commerce.Service.Services
{
    public class CartService(ICartRepository repository, IMapper mapper) : ICartService
    {
        public async Task DeleteCartAsync(string id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<CustomerCartDTO> GetByIdAsync(string id)
        {
            var cart = await repository.GetCartByIdAsync(id);
            return mapper.Map<CustomerCartDTO>(cart);
        }

        public async Task<CustomerCartDTO> UpdateAndCreateAsync(CustomerCartDTO customerCartDTO)
        {
            var cart = mapper.Map<CustomerCart>(customerCartDTO);
            var updatedCart = await repository.UpdateAndCreateAsync(cart);
            return mapper.Map<CustomerCartDTO>(updatedCart);
        }
    }
}
