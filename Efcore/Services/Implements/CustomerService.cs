
namespace Efcore.Services.Implements;

public sealed class CustomerService(IRepository<CustomerEntity> repository, IMapper mapper) : ICustomerService
{
    private readonly IRepository<CustomerEntity> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<uint> CreateAsync(CustomerEntity customer)
    {
        await _repository.CreateAsync(customer);

        return customer.Id;
    }

    public Task DeleteAsync(uint id)
    {
        throw new NotImplementedException();
    }

    public async Task<CustomerResponse> GetAsync(uint id)
    {
        var entt = await _repository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Não foi encontrado Cliente com identificação {id}.");

        return this._mapper.Map<CustomerResponse>(entt);
    }

    public Task UpdateAsync(CustomerRequest customer)
    {
        throw new NotImplementedException();
    }
}
