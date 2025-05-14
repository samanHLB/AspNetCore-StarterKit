namespace Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    public GenericRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    #region queries
    public async Task<T> GetAsync(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool tracking = false)
    {
        IQueryable<T> query = _db.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        if (where != null)
        {
            query = query.Where(where).AsSplitQuery();
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (tracking)
        {
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
        else
        {
            return await query.FirstOrDefaultAsync();
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool tracking = false)
    {
        IQueryable<T> query = _db.Set<T>();

        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (where != null)
        {
            query = query.Where(where);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (tracking)
        {
            return await query.AsNoTracking().ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public async Task<Tuple<List<T>, int>> GetWithPaginationAsync(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, Expression<Func<T, bool>>? search, bool tracking = false, int skip = 0, int take = 0)
    {
        IQueryable<T> query = _db.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        if (where != null)
        {
            query = query.Where(where);
        }

        if (search != null)
        {
            query = query.Where(search);
        }

        var count = query.Count();

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (tracking)
        {
            return Tuple.Create(await query.Skip(skip).Take(take).AsNoTracking().ToListAsync(), count);
        }
        else
        {
            return Tuple.Create(await query.Skip(skip).Take(take).ToListAsync(), count);
        }
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? where)
    {
        IQueryable<T> query = _db.Set<T>();

        if (where != null)
        {
            query = query.Where(where);
        }

        return await query.CountAsync();
    }

    public dynamic Max(Func<T, dynamic> columnSelector, Expression<Func<T, bool>>? where)
    {
        IQueryable<T> query = _db.Set<T>();

        if (where != null)
        {
            query = query.Where(where);
        }

        var GetMaxId = query.Max(columnSelector);

        return GetMaxId;
    }

    public dynamic Min(Func<T, dynamic> columnSelector, Expression<Func<T, bool>>? where)
    {
        IQueryable<T> query = _db.Set<T>();

        if (where != null)
        {
            query = query.Where(where);
        }

        var GetMaxId = query.Min(columnSelector);

        return GetMaxId;
    }

    public IQueryable<T> GetQuery(Expression<Func<T, bool>>? where, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool tracking = false)
    {
        IQueryable<T> query = _db.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        if (where != null)
        {
            query = query.Where(where);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (tracking)
        {
            return query.AsNoTracking();
        }
        else
        {
            return query;
        }
    }

    #endregion

    #region commands
    public async Task AddAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _db.Set<T>().AddRangeAsync(entities);
    }

    public void Delete(T entity)
    {
        _db.Set<T>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _db.Set<T>().RemoveRange(entities);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _db.Set<T>().Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _db.Set<T>().UpdateRange(entities);
    }

    #endregion
}
