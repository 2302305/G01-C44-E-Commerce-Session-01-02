using E_Commerce.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructureServices(this IServiceCollection Services,
            IConfiguration configuration)
        {

            //Services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.SectionName));

            Services.AddScoped<ITokenService, TokenService>();



            return Services;
        }
    }
}
