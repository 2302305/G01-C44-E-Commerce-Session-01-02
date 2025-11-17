
internal class Repository<TEntity, TKey>(ApplicationDbContext applicationDbContext) :
    IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    public void Add(TEntity entity) => applicationDbContext.Set<TEntity>().Add(entity);
    public async Task<TEntity?> GetByIdAsync(TKey Id, CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().FindAsync(Id, cancellationToken);
    }

    public void Remove(TEntity entity) => applicationDbContext.Set<TEntity>().Remove(entity);

    public void Update(TEntity entity) => applicationDbContext.Set<TEntity>().Update(entity);
    /// <summary>
    /// ////////////////////////////Get All Entities ////////////////////////////       
    /// </summary>
    /// <param name="GetAlls"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    async Task<TEntity?> IRepository<TEntity, TKey>.GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().ApplySpecification(specification).CountAsync(cancellationToken);
    }
}

