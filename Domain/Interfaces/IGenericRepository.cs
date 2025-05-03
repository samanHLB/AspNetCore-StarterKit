namespace Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = false);

    Task<int> GetAllCountAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null);

    Task<IEnumerable<T>> GetWithPaginationAsync2(Expression<Func<T, bool>> where = null, int skip = 0, int take = 0, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Expression<Func<T, bool>> search = null, bool tracking = false);

    Task<Tuple<List<T>, int>> GetWithPaginationAsync(Expression<Func<T, bool>> where = null, int skip = 0, int take = 0, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            , Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Expression<Func<T, bool>> search = null, bool tracking = false);

    Task<T> GetAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>
        , IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool tracking = false);

    Task<T> GetLocalAsync(Expression<Func<T, bool>> where = null, bool tracking = false);
    Task<bool> ExistAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>,
        IIncludableQueryable<T, object>> include = null);

    dynamic Max(Func<T, dynamic> columnSelector, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    dynamic Min(Func<T, dynamic> columnSelector, Expression<Func<T, bool>> where = null);

    Task AddAsync(T entity);
    void Add(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    void Detach(T entity, T local);
    Task SaveAsync();
    void Save();
}
