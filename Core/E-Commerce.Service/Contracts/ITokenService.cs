using E_Commerce.Domain.Entities.Authentication;

namespace E_Commerce.Service.Contracts;

public interface ITokenService
{
    string GetToken(AppUser User, IList<string> Roles);
}