using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RMM.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null,

                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,

                                        string includeString = null,

                                        bool disableTracking = true);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null,

                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,

                                       List<Expression<Func<T, object>>> includes = null,

                                       bool disableTracking = true);
        Task<T> GetByIdAsync(Guid? id);
        Task<T> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        //Task<Guid> DeleteAsync(T entity);
        Task<Guid> DeleteAsync(T entity);

    }
}
