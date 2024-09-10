
namespace Efcore.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders  { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<PaymentEntity> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderEnttConfig());
        modelBuilder.ApplyConfiguration(new CustomerEnttConfig());
        modelBuilder.ApplyConfiguration(new ProductEnttConfig());
        modelBuilder.ApplyConfiguration(new OrderItemEnttConfig());
        modelBuilder.ApplyConfiguration(new PaymentsEnttConfig());
    }
}
