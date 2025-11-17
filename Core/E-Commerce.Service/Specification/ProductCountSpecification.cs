namespace E_Commerce.Service.Specification
{
    internal sealed class ProductCountSpecification : BaseSpecification<Product>
    {
        public ProductCountSpecification(ProductQueryParameters productQueryParameters) : base(CreateCriteria(productQueryParameters))
        {
        }
        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters productQueryParameters)
        {
            return p => (!productQueryParameters.BrandId.HasValue || p.BrandId == productQueryParameters.BrandId.Value) &&
            (!productQueryParameters.TypeId.HasValue || p.TypeId == productQueryParameters.TypeId.Value) &&
            (string.IsNullOrWhiteSpace(productQueryParameters.Search) || p.Name.Contains(productQueryParameters.Search));
        }
    }
}
