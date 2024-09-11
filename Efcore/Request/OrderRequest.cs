namespace Efcore.Request;

public record OrderCreateRequest(string Description,decimal Value,PaymentType PaymentType,uint CustomerId);
public record OrderUpdateRequest(uint Id, string Description, decimal Value, PaymentType PaymentType);
public class OrderRequest
{
    public uint Id { get; set; }
}
