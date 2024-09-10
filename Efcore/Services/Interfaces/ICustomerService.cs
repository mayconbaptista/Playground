namespace Efcore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerEntity> CreateAsync(CustomerEntity customer);
        Task<CustomerEntity> UpdateAsync(CustomerEntity customer);
        Task<CustomerEntity> DeleteAsync(CustomerEntity customer);
        Task<CustomerEntity> GetAsync(uint id);
    }
}
