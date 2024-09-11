
namespace Efcore.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    private readonly ILoggerFactory _logger = LoggerFactory.Create(builder => builder.AddConsole());

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder
            .UseLoggerFactory(_logger)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .AddInterceptors(new ConnectionInterceptor());
    }
}
