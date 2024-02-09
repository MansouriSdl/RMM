using Microsoft.EntityFrameworkCore;
using RMM.Common;
using RMM.Contracts.Persistence;
using RMM.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RMM.Repositories.Abstarction
{
    public class RepositoryBase<T>: IAsyncRepository<T> where T : EntityBase
    {
        protected readonly ReportingDbContext context;
        public RepositoryBase(ReportingDbContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<Guid> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrEmpty(includeString))
            {


                if (includeString.Contains(","))
                {
                    var includeBeforeChar = includeString.Substring(0, includeString.IndexOf(","));
                    var includeAfterChar = includeString.Substring(includeString.IndexOf(",") + 1);
                    query = query.Include(includeBeforeChar).Include(includeAfterChar);

                }

                else query = query.Include(includeString);
            }
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();

        }
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        private static IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties, IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task<T> GetByIdAsync(Guid? id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = await context.SaveChangesAsync();
            return result;
        }

    }
}
