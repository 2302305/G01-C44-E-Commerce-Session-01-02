namespace E_Commerce.Domain.Contracts;

public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    //Get
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    //GetById
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    //Add 
    public void Add(TEntity entity);
    //Remove
    public void Remove(TEntity entity);

    //Update
    public void Update(TEntity entity);
}

