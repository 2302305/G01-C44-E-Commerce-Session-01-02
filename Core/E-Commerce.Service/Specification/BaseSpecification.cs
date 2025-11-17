namespace E_Commerce.Service.Specification;

public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    public BaseSpecification(Expression<Func<TEntity, bool>> criterea)
    {
        Criterea = criterea;
    }
    public Expression<Func<TEntity, bool>> Criterea { get; private set; }

    public ICollection<Expression<Func<TEntity, object>>> Includes { get; private set; } = [];

    protected void AddIncludes(Expression<Func<TEntity, object>> expression)
    {
        Includes.Add(expression);
    }
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }

    public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }
    protected void AddOrderBy(Expression<Func<TEntity, object>> expression) => OrderBy = expression;
    protected void AddOrderByDesc(Expression<Func<TEntity, object>> expression) => OrderByDesc = expression;
    /// <summary>/// Pagination Method
    public int Skip { get; private set; }

    public int Take { get; private set; }

    public bool IsPaginated { get; private set; }
    protected void ApplyPagination(int PageSize, int PageIndex)
    {
        IsPaginated = true;
        Skip = PageSize * (PageIndex - 1);
        Take = PageSize;
    }
}

