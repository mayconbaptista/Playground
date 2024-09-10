
namespace Efcore.Services.Implements;

public sealed class CustomerService : ICustomerService
{
    private readonly IRepository<CustomerEntity> _repository;

    public CustomerService(IRepository<CustomerEntity> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerEntity> CreateAsync(CustomerEntity customer)
    {
        return await _repository.CreateAsync(customer);
    }

    public Task<CustomerEntity> DeleteAsync(CustomerEntity customer)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerEntity> GetAsync(uint id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerEntity> UpdateAsync(CustomerEntity customer)
    {
        throw new NotImplementedException();
    }
}
