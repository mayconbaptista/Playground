namespace Efcore.AutoMapper;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region "Order"
        CreateMap<OrderEntity, OrderGetByIdResponse>();
        CreateMap<OrderCreateRequest, OrderEntity>();
        CreateMap<OrderUpdateRequest, OrderEntity>();
        CreateMap<OrderEntity, OrderEntity>();
        CreateMap<OrderItemEntity, OrderItemEntity>();
        #endregion
    }
}
