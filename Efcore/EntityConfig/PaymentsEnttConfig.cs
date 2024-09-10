
namespace Efcore.EntityConfig;

public sealed class PaymentsEnttConfig : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.ToTable("PAYMENT");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("payment_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OrderId)
            .HasColumnName("order_id")
            .IsRequired(true);

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired(true);

        builder.Property(x => x.Installments)
            .HasColumnName("installments")
            .IsRequired(true);

        builder.Property(x => x.Value)
            .HasColumnName("value")
            .HasColumnType("decimal(10,2)")
            .IsRequired(true);

    }
}
