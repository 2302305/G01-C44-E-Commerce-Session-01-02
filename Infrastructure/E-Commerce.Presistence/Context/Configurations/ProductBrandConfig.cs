using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Presentation.Context.Configurations
{
    internal class ProductBrandConfig : IEntityTypeConfiguration<ProductBrand>
    {
        void IEntityTypeConfiguration<ProductBrand>.Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnType("Nvarchar");
        }
    }
}
