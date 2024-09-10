namespace Efcore.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemEntity> CreateAsync(OrderItemEntity orderItem);
        Task<OrderItemEntity> UpdateAsync(OrderItemEntity orderItem);
        Task<OrderItemEntity> DeleteAsync(OrderItemEntity orderItem);
        Task<OrderItemEntity> GetAsync(uint id);
    }
}
