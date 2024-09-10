using System.Linq.Expressions;

namespace Efcore.Repository.Implements
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, bool tracking = true)
        {
            IQueryable<TEntity> query = this.dbSet.AsSingleQuery();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate, bool tracking = true)
        {
            IQueryable<TEntity> query = this.dbSet.AsSingleQuery();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if(!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(uint id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public void Update (TEntity entity)
        {
            this.dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await this.context.DisposeAsync();
        }
    }
}
