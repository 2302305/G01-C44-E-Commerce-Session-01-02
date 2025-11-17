using E_Commerce.Domain.Entities.Authentication;
using E_Commerce.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Infrastructure.Service
{
    public class TokenService(IConfiguration configuration, IOptions<JWTOptions> options) : ITokenService
    {
        public string GetToken(AppUser User, IList<string> Roles)
        {
            //Create Claims [Roles-User]



            var jwt = options.Value;

            List<Claim> claims = [

                new(JwtRegisteredClaimNames.Name,User.DisplayName),
                new(JwtRegisteredClaimNames.Name,User.Email)

                ];
            foreach (var Role in Roles)
            {
                claims.Add(new(ClaimTypes.Role, Role));
            }
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(claims: claims, issuer: jwt.Issuer, audience: jwt.Audience, expires: DateTime.Now.AddHours(jwt.DurationInHours), signingCredentials: SigningCredentials);
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
