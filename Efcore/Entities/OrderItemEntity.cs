
namespace Efcore.Entities;

public sealed class OrderItemEntity : BaseEntity
{
    public uint OrderId { get; set; }
    public uint ProductId { get; set; }
    public uint SellerId { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingCharges { get; set; }

    public ProductEntity? product { get; set; }
    public OrderEntity? Order { get; set; }

    public OrderItemEntity(uint orderId, uint productId, uint sellerId, decimal price, decimal shippingCharges)
    {
        var validator = new ValidationDomain();
        validator.when(price <= 0, "O preço do item deve ser uma valor válido maior que zero.");
        validator.when(shippingCharges < 0, "O valor do frete deve ser um valor válido.");
        validator.Execute();

        OrderId = orderId;
        ProductId = productId;
        SellerId = sellerId;
        Price = price;
        ShippingCharges = shippingCharges;
    }

    public void updatePrice(decimal price)
    {
        var validator = new ValidationDomain();
        validator.when(price <= 0, "O preço do item deve ser uma valor válido maior que zero.");
        validator.Execute();

        Price = price;
    }

    public void updateShippingCharges(decimal shippingCharges)
    {
        var validator = new ValidationDomain();
        validator.when(shippingCharges < 0, "O valor do frete deve ser um valor válido.");
        validator.Execute();

        ShippingCharges = shippingCharges;
    }
}
