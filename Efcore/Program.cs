
var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddControllers();

#region "Services"
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
#endregion

#region "Repositories"
builder.Services.AddScoped<IRepository<CustomerEntity>, Repository<CustomerEntity>>();
builder.Services.AddScoped<IRepository<OrderEntity>, Repository<OrderEntity>>();
builder.Services.AddScoped<IRepository<ProductEntity>, Repository<ProductEntity>>();
builder.Services.AddScoped<IRepository<OrderItemEntity>, Repository<OrderItemEntity>>();
builder.Services.AddScoped<IRepository<PaymentEntity>, Repository<PaymentEntity>>();
#endregion


string mySqlConnection = builder.Configuration.GetConnectionString("OrderDbConnection") ?? throw new Exception("Erro ao obter a string de conecção");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});


app.Run();

