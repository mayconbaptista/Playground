
namespace Efcore.EntityConfig;

public sealed class OrderEnttConfig : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("ORDER");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("order_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired(true);

        builder.Property(x => x.Pucherse)
            .HasColumnName("purchase_timestamp")
            .HasColumnType("datetime")
            .IsRequired(true);

        builder.Property(x => x.ApprovedAt)
            .HasColumnName("approved_at")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(x => x.Delivered)
            .HasColumnName("delivered_timestamp")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(x => x.EstimatedDelivery)
            .HasColumnName("estimated_delivery")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .HasConstraintName("fk_order_customer")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
