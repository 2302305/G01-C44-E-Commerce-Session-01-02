using E_Commerce.Presentation.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce.Web.Controllers
{
    public class ProductsController(IProductService service) : ApiBaseController
    {
        //Get All Products (Filteratiuon - search - order - Pagination) => Dto
        [RedisCache]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResponse>>> GetAllProducts([FromQuery] ProductQueryParameters parameters, CancellationToken cancellationToken = default)
        {
            var response = await service.GetAllProductsAsync(parameters, cancellationToken);
            return Ok(response);
        }
        //Get Product By Id(int Id) =>returns Dto 
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductResponse>> GetProductByIdAsync(int Id, CancellationToken
            cancellationToken = default)
        {
            var response = await service.GetProductByIdAsync(Id, cancellationToken);

            //return response is not null ? Ok(response) :
            //    NotFound(new ProblemDetails
            //    {
            //        Title = "Endpoint Not Found",
            //        Detail = $" Product With The ID {Id} is Not Found",
            //        Status = StatusCodes.Status404NotFound,
            //    });
            return HandleResult(response);
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
