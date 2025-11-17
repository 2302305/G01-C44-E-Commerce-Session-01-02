using E_Commerce.Shared.DataTrensferObject.Cart;
using E_Commerce.Web.Controllers;

namespace E_Commerce.Presentation.Controllers
{
    public class CartsController(ICartService cartService) : ApiBaseController
    {
        //Update
        [HttpPost]
        public async Task<ActionResult<CustomerCartDTO>> UpdateAndCreateCartAsync([FromBody] CustomerCartDTO customerCartDTO)
        {
            return Ok(await cartService.UpdateAndCreateAsync(customerCartDTO));
        }
        //GetById
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerCartDTO>> GeTByIdAsync(string Id)
        {

            return await cartService.GetByIdAsync(Id);
        }
        //Delete 
        [HttpDelete]
        public async Task<ActionResult<CustomerCartDTO>> DeleteCartAsync(string Id)
        {

            await cartService.DeleteCartAsync(Id);
            return NoContent();
        }
    }
}
