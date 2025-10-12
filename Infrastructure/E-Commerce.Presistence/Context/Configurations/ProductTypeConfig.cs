using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Presentation.Context.Configurations
{
    internal class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
    {
        void IEntityTypeConfiguration<ProductType>.Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnType("Nvarchar");
        }
    }
}
