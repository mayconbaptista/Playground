using System.Text.Json.Serialization;

namespace Efcore.Response;

public record OrderGetByIdResponse(uint Id, string Description, decimal Value, PaymentType PaymentType, uint CustomerId);

[JsonSerializable(typeof(OrderGetByIdResponse))]
public partial class OrderResponse : JsonSerializerContext
{

}
