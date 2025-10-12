namespace E_Commerce.Service.Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper imapper) : IProductService
    {
        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(cancellationToken);
            return imapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken)
        {
            var Brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync(cancellationToken);
            return imapper.Map<IEnumerable<BrandResponse>>(Brands);
        }

        public async Task<ProductResponse?> GetProductByIdAsync(int Id, CancellationToken cancellationToken)
        {
            var Products = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(Id, cancellationToken);
            return imapper.Map<ProductResponse>(Products);
        }

        public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken)
        {
            var Types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync(cancellationToken);
            return imapper.Map<IEnumerable<TypeResponse>>(Types);
        }
    }
}
