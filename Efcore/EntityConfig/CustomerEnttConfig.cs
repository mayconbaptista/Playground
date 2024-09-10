
namespace Efcore.EntityConfig
{
    public sealed class CustomerEnttConfig : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("CUSTOMER");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("customer_id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ZipCode)
                .HasColumnName("zip_code")
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(x => x.City)
                .HasColumnName("city")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.State)
                .HasColumnName("state")
                .HasMaxLength(2)
                .IsRequired(true);
        }
    }
}
