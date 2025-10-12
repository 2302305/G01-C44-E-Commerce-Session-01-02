
namespace E_Commerce.Service.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
            .ForMember(p => p.ProductBrand, o => o
            .MapFrom(s => s.ProductBrand.Name))
            .ForMember(p => p.ProductType, o => o
            .MapFrom(s => s.ProductType.Name))
            .ForMember(p => p.PictureUrl, o => o
            .MapFrom<PictureUrlResolver>());


            CreateMap<ProductBrand, BrandResponse>();
            CreateMap<ProductType, TypeResponse>();

        }
    }
}
internal class PictureUrlResolver(IConfiguration configuration) :
    IValueResolver<Product, ProductResponse, string?>
{
    public string? Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl))
        {
            return null;
        }
        return $"{configuration["BaseUrl"]}{source.PictureUrl}";
    }

}