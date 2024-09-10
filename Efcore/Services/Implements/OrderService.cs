
namespace Efcore.Services.Implements
{
    public sealed class OrderService : IOrderService
    {
        public readonly IRepository<OrderEntity> _repository;

        public OrderService(IRepository<OrderEntity> repository)
        {
            _repository = repository;
        }
        public Task<OrderEntity> CreateAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> DeleteAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderEntity> GetAsync(uint id)
        {
            var result = await _repository.GetByIdAsync(id) ?? throw new Exception("Order not found");

            return result;
        }

        public Task<OrderEntity> UpdateAsync(OrderEntity order)
        {
            throw new NotImplementedException();
        }
    }
}
