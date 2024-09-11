namespace Efcore.AutoMapper;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region "Requests to Entity"
        #region "Order requets"
        CreateMap<OrderEntity, OrderGetByIdResponse>();
        CreateMap<OrderCreateRequest, OrderEntity>();
        CreateMap<OrderUpdateRequest, OrderEntity>();
        CreateMap<OrderEntity, OrderEntity>();
        CreateMap<OrderItemEntity, OrderItemEntity>();
        #endregion

        #region "Customer requests"
        CreateMap<CustomerCreateRequest, CustomerEntity>()
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.zipCodePrefix))
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.state));
        #endregion
        #endregion
        #region "Entity to Response"
        CreateMap<CustomerEntity, CustomerResponse>()
            .ForMember(dest => dest.ZipCodePrefix, opt => opt.MapFrom(src => src.ZipCode))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.City, opt => opt.MapFrom( src => src.City));
        #endregion
    }
}
