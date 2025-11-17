using E_Commerce.Domain.Entities.Authentication;
using E_Commerce.Presistence.AuthContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace E_Commerce.Presistence.DbInitializers
{
    internal class DbInitializer(ApplicationDbContext applicationDbContext, AuthDbContext authDbContext,
        RoleManager<IdentityRole> roleManager
        , UserManager<AppUser> userManager,
        ILogger<DbInitializer> logger) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                if ((await applicationDbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await applicationDbContext.Database.MigrateAsync();
                }

                if (!applicationDbContext.ProductBrands.Any())
                {
                    var brandsData = await File.ReadAllTextAsync(
                        Path.Combine(AppContext.BaseDirectory, "Context", "DataSeed", "brands.json")
                    );
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData, options);
                    if (brands?.Any() == true)
                    {
                        applicationDbContext.ProductBrands.AddRange(brands);
                        await applicationDbContext.SaveChangesAsync();
                    }
                }

                if (!applicationDbContext.ProductsType.Any())
                {
                    var typesData = await File.ReadAllTextAsync(
                        Path.Combine(AppContext.BaseDirectory, "Context", "DataSeed", "types.json")
                    );
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData, options);
                    if (types?.Any() == true)
                    {
                        applicationDbContext.ProductsType.AddRange(types);
                        await applicationDbContext.SaveChangesAsync();
                    }
                }

                if (!applicationDbContext.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync(
                        Path.Combine(AppContext.BaseDirectory, "Context", "DataSeed", "Products.json")
                    );
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData, options);
                    if (products?.Any() == true)
                    {
                        applicationDbContext.Products.AddRange(products);
                        await applicationDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error during database initialization: {ex.Message}");
            }
        }
        public async Task InitializeAuthDbAsync()
        {
            //Migrate AuthDbContext

            await authDbContext.Database.MigrateAsync();



            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }
            if (!userManager.Users.Any())
            {
                var SuperAdminUser = new AppUser
                {
                    DisplayName = "Super Admin",
                    Email = "SuperAdmin@gmail.com",
                    UserName = "SuperAdmin",
                    PhoneNumber = "01128938222",
                };
                var AdminUser = new AppUser
                {
                    DisplayName = "AdminUser",
                    Email = "AdminUser@gmail.com",
                    UserName = "AdminUser",
                    PhoneNumber = "01128938222",
                };
                await userManager.CreateAsync(SuperAdminUser, "saif@123");
                await userManager.CreateAsync(AdminUser, "saif@123");
                await userManager.AddToRoleAsync(SuperAdminUser, "SuperAdmin");
                await userManager.AddToRoleAsync(AdminUser, "Admin");

            }
            // Default Roles=> Roles Manager
            // Default User=> User Manager
        }
    }
}
