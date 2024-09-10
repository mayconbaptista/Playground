
namespace Efcore.EntityConfig;

public class ProductEnttConfig : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("PRODUCT");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("product_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CategoryName)
            .HasColumnName("category_name")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(x => x.WeightG)
            .HasColumnName("weight_g")
            .IsRequired(true);

        builder.Property(x => x.LengthCm)
            .HasColumnName("length_cm")
            .IsRequired(true);

        builder.Property(x => x.WidthCm)
            .HasColumnName("width_cm")
            .IsRequired(true);

        builder.Property(x => x.HeightCm)
            .HasColumnName("height_cm")
            .IsRequired(true);
    }
}
