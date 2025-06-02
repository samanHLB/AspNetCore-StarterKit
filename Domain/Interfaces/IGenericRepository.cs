namespace Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    // queries
    Task<T> GetAsync(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracking = false);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracking = false);
    Task<Tuple<List<T>, int>> GetWithPaginationAsync(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Expression<Func<T, bool>>? search = null, bool tracking = false, int skip = 0, int take = 0);
    Task<int> CountAsync(Expression<Func<T, bool>>? where = null);
    dynamic Max(Func<T, dynamic> columnSelector, Expression<Func<T, bool>>? where = null);
    dynamic Min(Func<T, dynamic> columnSelector, Expression<Func<T, bool>>? where = null);
    IQueryable<T> GetQuery(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracking = false);

    // commands
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task SaveAsync();
}
