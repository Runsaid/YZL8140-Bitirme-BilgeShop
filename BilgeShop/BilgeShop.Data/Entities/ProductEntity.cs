using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BilgeShop.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        // Relational Property

        public CategoryEntity Category { get; set; }

    }

    public class ProductEntityConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.UnitPrice)
                .IsRequired(false);

            builder.Property(x => x.ImagePath)
                .IsRequired(false);

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.UnitInStock)
                .IsRequired();

        }
    }
}
