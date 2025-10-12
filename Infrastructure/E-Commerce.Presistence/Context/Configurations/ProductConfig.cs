using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Presentation.Context.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnType("Nvarchar");

            builder.Property(p => p.Description).HasMaxLength(1024);

            builder.Property(p => p.PictureUrl);

            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");

            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.TypeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
