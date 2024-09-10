namespace Efcore.Request;

public record OrderCreateRequest(string Description,decimal Value,PaymentType PaymentType,uint CustomerId);
public record OrderUpdateRequest(string Description, decimal Value, PaymentType PaymentType);
public class OrderRequest
{}
