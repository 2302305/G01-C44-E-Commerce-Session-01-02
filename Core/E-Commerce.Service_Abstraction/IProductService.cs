using ECommerce.ServicesAbstractions.Common;

namespace E_Commerce.Service_Abstraction
{
    public interface IProductService
    {
        //Get All Products (Filteratiuon - search - order - Pagination) => Dto
        public Task<PaginatedResult<ProductResponse>> GetAllProductsAsync(ProductQueryParameters productQueryParameters, CancellationToken cancellationToken);
        //Get Product By Id(int Id) =>returns Dto
        public Task<Result<ProductResponse>> GetProductByIdAsync(int Id, CancellationToken cancellationToken = default);
        //Get Brands
        public Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default);
        //Get Types
        public Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default);
    }
}
