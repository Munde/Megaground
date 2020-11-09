using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Megaground.SharedKenel.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Gets data from the db set asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);


        /// <summary>
        /// Method for creating Records the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities);


        /// <summary>
        /// Methods for Deleting records asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> RemoveRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Update details of the entity
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        Task UpdateEntity(TEntity entityToUpdate);

        ValueTask<int> SaveChangesAsync();
    }
}
