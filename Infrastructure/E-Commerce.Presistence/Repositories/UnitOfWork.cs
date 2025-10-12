namespace E_Commerce.Presistence.Repositories
{
    public class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork
    {
        private Dictionary<string, object> _Repo = [];
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await applicationDbContext.SaveChangesAsync(cancellationToken);
        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : Entity<TKey>
        {
            var typeName = typeof(TEntity).Name;

            if (_Repo.TryGetValue(typeName, out object? value))
            {
                return (value as IRepository<TEntity, TKey>)!;
            }
            var repo = new Repository<TEntity, TKey>(applicationDbContext);
            _Repo.Add(typeName, repo);
            return repo;
        }
    }
}
