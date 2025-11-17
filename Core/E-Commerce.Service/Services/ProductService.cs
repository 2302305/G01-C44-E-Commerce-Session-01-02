using E_Commerce.Service.Specification;
using ECommerce.ServicesAbstractions.Common;

namespace E_Commerce.Service.Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper imapper) : IProductService
    {
        public async Task<PaginatedResult<ProductResponse>> GetAllProductsAsync(ProductQueryParameters productQueryParameters, CancellationToken cancellationToken)
        {
            var specification = new ProductWithBrandTypeSpecification(productQueryParameters);

            var data = await unitOfWork.GetRepository<Product, int>()
                .GetAllAsync(specification, cancellationToken);
            var TotalCount = await unitOfWork.GetRepository<Product, int>()
                .CountAsync(new ProductCountSpecification(productQueryParameters), cancellationToken);
            var products = imapper.Map<IEnumerable<ProductResponse>>(data);
            return new(productQueryParameters.PAgeIndex,
                TotalCount,
                products.Count(), products);
        }
        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken)
        {
            var Brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync(cancellationToken);
            return imapper.Map<IEnumerable<BrandResponse>>(Brands);
        }

        public async Task<Result<ProductResponse>> GetProductByIdAsync(int Id, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetRepository<Product, int>()
                .GetAsync(new ProductWithBrandTypeSpecification(Id), cancellationToken);
            if (product == null)
            {
                return Error.NotFound();
            }
            return imapper.Map<ProductResponse>(product);//Implicit Cast
        }

        public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken)
        {
            var Types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync(cancellationToken);
            return imapper.Map<IEnumerable<TypeResponse>>(Types);
        }
    }
}
