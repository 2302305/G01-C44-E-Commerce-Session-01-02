namespace E_Commerce.Presentation.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
    : DbContext(dbContextOptions)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductsType { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }
}

