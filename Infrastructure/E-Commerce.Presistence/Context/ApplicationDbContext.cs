namespace E_Commerce.Presentation.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Product> products { get; set; }
    public DbSet<ProductType> productsType { get; set; }
    public DbSet<ProductBrand> productBrands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

