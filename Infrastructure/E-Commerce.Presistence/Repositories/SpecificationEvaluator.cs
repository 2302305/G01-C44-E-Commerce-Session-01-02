namespace E_Commerce.Presistence.Repositories
{
    //Write the query without excecution bcs it cannot be written in the Repo Implementation for the easeness of maintainability
    /// <summary> The Purpose of doing a Specification Evaluatot 
    ///Easier to maintain
    //Easier to reuse
    //Easier to test
    //order
    //pagination
    //sort
    //search
    //Filteration
    /// </summary>
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> ApplySpecification<TEntity>(this IQueryable<TEntity> _dbset,
            ISpecification<TEntity> specification) where TEntity : class
        {
            var query = _dbset;
            ///For Each
            if (specification.Criterea is not null)
            {
                query = query.Where(specification.Criterea);
            }
            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDesc is not null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }
            if (specification.IsPaginated)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }
            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }
            ///Agregate Function Iteration
            //query = specification.Includes.Aggregate(query, (query, include) => query.Include(include));

            return query;
        }

    }
}
