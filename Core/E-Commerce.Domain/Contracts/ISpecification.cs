
using System.Linq.Expressions;

public interface ISpecification<TEntity>
    where TEntity : class
{
    //Includes Returns takes Excepression of `Func <TEntity,TKey> 
    ICollection<Expression<Func<TEntity, object>>> Includes { get; }
    Expression<Func<TEntity, bool>> Criterea { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDesc { get; }
    int Skip { get; }
    int Take { get; }
    bool IsPaginated { get; }

}