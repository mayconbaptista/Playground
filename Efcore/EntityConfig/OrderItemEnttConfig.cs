namespace Efcore.EntityConfig;

public sealed class OrderItemEnttConfig : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.ToTable("ORDER_ITEM");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("order_item_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasColumnName("order_id")
            .IsRequired(true);

        builder.Property(x => x.ProductId)
            .HasColumnName("product_id")
            .IsRequired(true);

        builder.Property(x => x.SellerId)
            .HasColumnName("seller_id")
            .IsRequired(true);

        builder.Property(x => x.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(10,2)")
            .IsRequired(true);

        builder.Property(x => x.ShippingCharges)
            .HasColumnName("shipping_charges")
            .HasColumnType("decimal(10,2)")
            .IsRequired(true);

        builder.HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .HasConstraintName("fk_order_item_order")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .HasConstraintName("fk_order_item_product")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
