using System.Linq.Expressions;

namespace Efcore.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(uint id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, bool tracking = true);
    Task<TEntity> CreateAsync(TEntity entity);
    void Update (TEntity entity);
    void Delete (TEntity entity);
    Task SaveChangesAsync();
    Task DisposeAsync();
}
