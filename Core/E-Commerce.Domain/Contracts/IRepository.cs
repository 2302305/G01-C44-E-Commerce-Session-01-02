namespace E_Commerce.Domain.Contracts;

public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    //Get
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    //GetAll Products , Brands , Types
    Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);

    //GetById
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TEntity?> GetAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    //Add 
    public void Add(TEntity entity);
    //Remove
    public void Remove(TEntity entity);

    //Update
    public void Update(TEntity entity);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
}

