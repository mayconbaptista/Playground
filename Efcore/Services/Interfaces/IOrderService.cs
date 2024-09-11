namespace Efcore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<uint> CreateAsync(OrderCreateRequest order);
        Task<OrderResponse> GetByIdAsync(uint id);
        Task UpdateAsync(OrderUpdateRequest order);
        Task DeleteAsync (uint id);
    }
}
