namespace E_Commerce.Service.Specification
{
    public class ProductWithBrandTypeSpecification : BaseSpecification<Product>
    {
        //GetAll
        public ProductWithBrandTypeSpecification(ProductQueryParameters productQueryParameters) :
            base(CreateCriteria(productQueryParameters))
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            switch (productQueryParameters.Sort)
            {
                case ProductSorting.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSorting.NameDesc:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSorting.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSorting.PriceDesc:
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;


            }
            ApplyPagination(productQueryParameters.PageSize, productQueryParameters.PAgeIndex);
        }
        public ProductWithBrandTypeSpecification(int id) : base(c => c.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        }
        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters productQueryParameters)
        {
            return p => (!productQueryParameters.BrandId.HasValue || p.BrandId == productQueryParameters.BrandId.Value) &&
            (!productQueryParameters.TypeId.HasValue || p.TypeId == productQueryParameters.TypeId.Value) &&
            (string.IsNullOrWhiteSpace(productQueryParameters.Search) || p.Name.Contains(productQueryParameters.Search));
        }
    }
}
