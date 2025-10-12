using System.Text.Json;

namespace E_Commerce.Presistence.DbInitializers
{
    internal class DbInitializer(ApplicationDbContext applicationDbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                if ((await applicationDbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await applicationDbContext.Database.MigrateAsync();
                }

                if (!applicationDbContext.productBrands.Any())
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
                        applicationDbContext.productBrands.AddRange(brands);
                        await applicationDbContext.SaveChangesAsync();
                    }
                }

                if (!applicationDbContext.productsType.Any())
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
                        applicationDbContext.productsType.AddRange(types);
                        await applicationDbContext.SaveChangesAsync();
                    }
                }

                if (!applicationDbContext.products.Any())
                {
                    var productsData = await File.ReadAllTextAsync(
                        Path.Combine(AppContext.BaseDirectory, "Context", "DataSeed", "products.json")
                    );
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData, options);
                    if (products?.Any() == true)
                    {
                        applicationDbContext.products.AddRange(products);
                        await applicationDbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error during database initialization: {ex.Message}");
            }
        }
    }
}
