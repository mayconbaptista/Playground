namespace Efcore.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentEntity> CreateAsync(PaymentEntity payment);
        Task<PaymentEntity> UpdateAsync(PaymentEntity payment);
        Task DeleteAsync(uint id);
        Task<PaymentEntity> GetAsync(uint id);
    }
}
