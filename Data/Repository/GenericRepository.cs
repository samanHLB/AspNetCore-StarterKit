namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _db.Set<T>().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }

        public void Detach(T entity, T local)
        {
            if (local != null)
            {
                _db.Entry(local).State = EntityState.Detached;
            }
            _db.Entry(entity).State = EntityState.Modified;

        }

        public async Task<bool> ExistAsync(System.Linq.Expressions.Expression<Func<T, bool>> where = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

            query = query.Where(where);

            if (await query.CountAsync() > 0)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null, bool tracking = false)
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
                if (tracking)
                    return await orderBy(query).AsNoTracking().ToListAsync();
                else
                    return await orderBy(query).ToListAsync();

            }
            else
            {
                if (tracking)
                    return await query.AsNoTracking().ToListAsync();
                else
                    return await query.ToListAsync();
            }
        }

        public async Task<int> GetAllCountAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.CountAsync();
        }


        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null, bool tracking = false)
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
                if (tracking)
                    return await orderBy(query).AsNoTracking().FirstOrDefaultAsync();
                else
                    return await orderBy(query).FirstOrDefaultAsync();

            }
            else
            {
                if (tracking)
                    return await query.AsNoTracking().FirstOrDefaultAsync();
                else
                    return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<T> GetLocalAsync(Expression<Func<T, bool>> where = null, bool tracking = false)
        {
            IQueryable<T> query = _db.Set<T>();

            if (where != null)
            {
                query = query.Where(where);
            }

            if (tracking)
                return await query.AsNoTracking().FirstOrDefaultAsync();
            else
                return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetWithPaginationAsync2(Expression<Func<T, bool>> where = null, int skip = 0, int take = 0, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Expression<Func<T, bool>> search = null, bool tracking = false)
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
            if (orderBy != null)
            {
                if (tracking)
                    return await orderBy(query).Skip(skip).Take(take).AsNoTracking().ToListAsync();
                else
                    return await orderBy(query).Skip(skip).Take(take).ToListAsync();

            }
            else
            {
                if (tracking)
                    return await query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
                else
                    return await query.Skip(skip).Take(take).ToListAsync();
            }

        }

        public async Task<Tuple<List<T>, int>> GetWithPaginationAsync(Expression<Func<T, bool>> where = null, int skip = 0, int take = 0, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Expression<Func<T, bool>> search = null, bool tracking = false)
        {
            int count = 0;
            //Tuple<IEnumerable<T>, int> tuple =Tuple.Create<T,int>(null, 0);
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
            count = query.Count();
            if (orderBy != null)
            {
                if (tracking)
                    return Tuple.Create(await orderBy(query).Skip(skip).Take(take).AsNoTracking().ToListAsync(), count);
                else
                    return Tuple.Create(await orderBy(query).Skip(skip).Take(take).ToListAsync(), count);

            }
            else
            {
                if (tracking)
                    return Tuple.Create(await query.Skip(skip).Take(take).AsNoTracking().ToListAsync(), count);
                else
                    return Tuple.Create(await query.Skip(skip).Take(take).ToListAsync(), count);
            }
        }

        public dynamic Max(Func<T, dynamic> columnSelector, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
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

            var GetMaxId = query.Max(columnSelector);
            return GetMaxId;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _db.Set<T>().UpdateRange(entities);
        }

        public dynamic Min(Func<T, dynamic> columnSelector, Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if (where != null)
            {
                query = query.Where(where);
            }

            var GetMaxId = query.Min(columnSelector);
            return GetMaxId;
        }
    }
}
