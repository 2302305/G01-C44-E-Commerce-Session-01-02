internal class Repository<TEntity, TKey>(ApplicationDbContext applicationDbContext) :
    IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    public void Add(TEntity entity) => applicationDbContext.Set<TEntity>().Add(entity);
    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public void Remove(TEntity entity) => applicationDbContext.Set<TEntity>().Remove(entity);

    public void Update(TEntity entity) => applicationDbContext.Set<TEntity>().Update(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) => await applicationDbContext.Set<TEntity>().ToListAsync(cancellationToken);
}

