
namespace Efcore.Entities;

public sealed class PaymentEntity : BaseEntity
{
    public uint OrderId { get; set; }   
    public uint PaymentFamilyId { get; set; }
    public PaymentType Type { get; set; }
    public ushort Installments { get; set; }
    public decimal Value { get; set; }

    public OrderEntity? Order { get; set; }

    public PaymentEntity(
               uint orderId,
               uint paymentFamilyId,
               PaymentType type,
               ushort installments,
               decimal value)
    {
        var validator = new ValidationDomain();
        validator.when(installments < 1 || installments > 12, "O numero de percelas deve ser um valor entre 1 e 12.");
        validator.when(value <= 0, "O valor do pagamento deve ser um valor válido.");
        validator.Execute();

        OrderId = orderId;
        PaymentFamilyId = paymentFamilyId;
        Type = type;
        Installments = installments;
        Value = value;
    }
}
