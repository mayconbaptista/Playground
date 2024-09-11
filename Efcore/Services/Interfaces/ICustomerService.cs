namespace Efcore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<uint> CreateAsync(CustomerEntity customer);
        Task UpdateAsync(CustomerRequest customer);
        Task DeleteAsync(uint id);
        Task<CustomerResponse> GetAsync(uint id);
    }
}
