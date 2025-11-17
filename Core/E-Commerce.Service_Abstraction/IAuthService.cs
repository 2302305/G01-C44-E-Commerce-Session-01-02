using E_Commerce.Shared.DataTransfererObjects.Auth;
using ECommerce.ServicesAbstractions.Common;

namespace E_Commerce.Service_Abstraction
{
    public interface IAuthService
    {
        Task<Result<UserResponse>> LoginAsync(LoginRequest loginRequest);
        Task<Result<UserResponse>> RegisterAsync(RegisterRequest registerRequest);
    }
}
