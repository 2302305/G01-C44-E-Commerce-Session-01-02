using E_Commerce.Domain.Entities.Authentication;
using E_Commerce.Service.Contracts;
using E_Commerce.Shared.DataTransfererObjects.Auth;
using ECommerce.ServicesAbstractions.Common;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Service.Services
{
    internal class AuthService(UserManager<AppUser> userManager, ITokenService tokenService) : IAuthService
    {
        public async Task<Result<UserResponse>> LoginAsync(LoginRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return Error.Unauthorized(description: "Invalid Email Or PAss");
            var result = await userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
                return Error.Unauthorized(description: "Invalid Email Or PAss");

            var roles = await userManager.GetRolesAsync(user);

            var token = tokenService.GetToken(user, roles);
            return new UserResponse(user.Email, user.DisplayName, token);

        }

        public async Task<Result<UserResponse>> RegisterAsync(RegisterRequest request)
        {
            var user = new AppUser
            {
                Email = request.Email,
                DisplayName = request.DisplayName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return result.Errors.Select(x => Error.Validation(x.Code, x.Description)).ToList();

            var token = tokenService.GetToken(user, []);
            return new UserResponse(user.Email, user.DisplayName, token);
        }

    }
}
