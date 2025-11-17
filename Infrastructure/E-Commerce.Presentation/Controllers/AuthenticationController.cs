using E_Commerce.Shared.DataTransfererObjects.Auth;
using E_Commerce.Web.Controllers;

namespace E_Commerce.Presentation.Controllers
{
    //baseUrl/api/Authentication
    public class AuthenticationController(IAuthService authService) : ApiBaseController
    {
        //Post-Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserResponse>> RegisterAsync(RegisterRequest request)
        {
            var result = await authService.RegisterAsync(request);
            return HandleResult(result);
        }

        //Post-login => Token 
        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> LoginAsync(LoginRequest request)
        {
            var result = await authService.LoginAsync(request);
            return HandleResult(result);
        }
        //{Authorization}
        //Get CurrentUser=>UserResponse for the validation of the user and his token 
        //{Authorization}
        //GetCurrentUSerAddress for checkOut
        //{Authorization}
        //UpdateUSerAddress 



    }
}
