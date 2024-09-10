
namespace Efcore.Services.Implements
{
    public sealed class PaymentService : IPaymentService
    {
        private readonly IRepository<PaymentEntity> _paymentRepository;

        public PaymentService(IRepository<PaymentEntity> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentEntity> CreateAsync(PaymentEntity payment)
        {
            var result = await _paymentRepository.CreateAsync(payment);
            await _paymentRepository.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(uint id)
        {
            var entity = await _paymentRepository.GetByIdAsync(id) ?? throw new Exception("Payment not found");

            _paymentRepository.Delete(entity);
            await _paymentRepository.SaveChangesAsync();
            return;
        }

        public async Task<PaymentEntity> GetAsync(uint id)
        {
            var result = await _paymentRepository.GetByIdAsync(id) ?? throw new Exception("Payment not found");

            return result;
        }

        public Task<PaymentEntity> UpdateAsync(PaymentEntity payment)
        {
            throw new NotImplementedException();
        }
    }
}
