namespace E_Commerce.Web.Controllers
{
    public class ProductsController(IProductService service) : ApiBaseController
    {
        //Get All Products (Filteratiuon - search - order - Pagination) => Dto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts(CancellationToken cancellationToken = default)
        {
            var response = await service.GetAllProductsAsync(cancellationToken);
            return Ok(response);
        }
        //Get Product By Id(int Id) =>returns Dto
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductByIdAsync(int id, CancellationToken
            cancellationToken = default)
        {
            var response = await service.GetProductByIdAsync(id, cancellationToken);
            return Ok(response);
        }
        //Get Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
        {
            var response = await service.GetBrandsAsync(cancellationToken);
            return Ok(response);
        }
        //Get Types 
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
        {
            var response = await service.GetTypesAsync(cancellationToken);
            return Ok(response);
        }

    }
}
