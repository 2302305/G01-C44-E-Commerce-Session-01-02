using E_Commerce.Domain.Entities.Authentication;
using E_Commerce.Presistence.AuthContext;
using E_Commerce.Presistence.Services;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Presistence.DependencyInjection
{
    public static class PresistenceServiceExtensions
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<ICartRepository, CartRepository>();
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                var ConnectionString = configuration.GetConnectionString("SQLConnection");
                options.UseSqlServer(ConnectionString);
            });
            service.AddDbContext<AuthDbContext>(options =>
            {
                var ConnectionString = configuration.GetConnectionString("AuthConnection");
                options.UseSqlServer(ConnectionString);

            });
            service.AddSingleton<IConnectionMultiplexer>(config =>
            {
                return ConnectionMultiplexer
                .Connect(configuration.GetConnectionString("RedisConnection")!);
            });
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ICasheService, CasheService>();
            service.AddScoped<IDbInitializer, DbInitializer>();
            ConfigureIdentity(service, configuration);
            return service;
        }
        private static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<AppUser>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireDigit = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>();
        }


    }

}
