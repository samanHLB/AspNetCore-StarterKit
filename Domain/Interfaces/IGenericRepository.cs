namespace Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    // queries
    Task<T> GetAsync(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool tracking = false);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool tracking = false);
    Task<Tuple<List<T>, int>> GetWithPaginationAsync(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, Expression<Func<T, bool>>? search, bool tracking = false, int skip = 0, int take = 0);
    Task<int> CountAsync(Expression<Func<T, bool>>? where);
    dynamic Max(Func<T, dynamic> columnSelector, Expression<Func<T, bool>>? where);
    dynamic Min(Func<T, dynamic> columnSelector, Expression<Func<T, bool>>? where);
    IQueryable<T> GetQuery(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool tracking = false);

    // commands
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task SaveAsync();
}
