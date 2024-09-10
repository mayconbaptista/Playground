
namespace Efcore.Services.Implements
{
    public sealed class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItemEntity> _repository;
        public Task<OrderItemEntity> CreateAsync(OrderItemEntity orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemEntity> DeleteAsync(OrderItemEntity orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemEntity> GetAsync(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemEntity> UpdateAsync(OrderItemEntity orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
