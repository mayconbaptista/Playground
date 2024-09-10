namespace Efcore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderEntity> CreateAsync(OrderEntity order);
        Task<OrderEntity> UpdateAsync(OrderEntity order);
        Task<OrderEntity> DeleteAsync(OrderEntity order);
        Task<OrderEntity> GetAsync(uint id);
    }
}
