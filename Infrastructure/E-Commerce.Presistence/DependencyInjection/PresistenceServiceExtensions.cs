namespace E_Commerce.Presistence.DependencyInjection
{
    public static class PresistenceServiceExtensions
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                var ConnectionString = configuration.GetConnectionString("SQLConnection");
                options.UseSqlServer(ConnectionString);
            });

            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IDbInitializer, DbInitializer>();
            return service;
        }
    }

}
