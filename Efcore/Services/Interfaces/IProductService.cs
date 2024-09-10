namespace Efcore.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductEntity> CreateAsync(ProductEntity product);
        Task<ProductEntity> UpdateAsync(ProductEntity product);
        Task<ProductEntity> DeleteAsync(ProductEntity product);
        Task<ProductEntity> GetAsync(uint id);
    }
}
