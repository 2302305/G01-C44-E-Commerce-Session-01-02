using E_Commerce.Domain.Entities.Cart;
using E_Commerce.Shared.DataTrensferObject.Cart;

namespace E_Commerce.Service.MappingProfiles
{
    internal class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartItem, CartItemDTO>()
                .ReverseMap();
            CreateMap<CustomerCart, CustomerCartDTO>()
                .ReverseMap();
        }
    }
}
