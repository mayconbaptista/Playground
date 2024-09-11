
using Efcore.Exceptions;

namespace Efcore.Services.Implements
{
    public sealed class OrderService(IRepository<OrderEntity> repository,IMapper mapper) : IOrderService
    {
        public readonly IRepository<OrderEntity> _repository = repository;
        public readonly IMapper _mapper = mapper;

        public Task<uint> CreateAsync(OrderCreateRequest order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> GetByIdAsync(uint id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderUpdateRequest order)
        {
            throw new NotImplementedException();
        }
    }
}
