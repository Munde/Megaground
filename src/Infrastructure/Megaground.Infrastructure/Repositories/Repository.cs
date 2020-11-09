using Megaground.Infrastructure.Data;
using Megaground.SharedKenel.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Megaground.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly MegagroundContext Context;
        protected DbSet<TEntity> Entities;

        public Repository(MegagroundContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets single record from the db set asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Guid id)
        {
            return await Context.
                Set<TEntity>().
                FindAsync(id);
        }

        /// <summary>
        /// Gets all records from the database
        /// asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.
                    Set<TEntity>().
                    ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
         Expression<Func<TEntity, bool>> filter = null,
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
         string includeProperties = "")
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }


        /// <summary>
        /// Finds the record in the database asynchronous using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = Context.Set<TEntity>().Where(predicate);
            return await Task.FromResult(result);
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates Records the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Context.
                Set<TEntity>()
                .AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Creates the range of entities asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            var enumerable = entities as TEntity[] ?? entities.ToArray();
            Context.Set<TEntity>().
                AddRange(enumerable);
            return await Task.FromResult(enumerable);
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes single Record from a database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return await Task.FromResult(entity);
        }


        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> RemoveRange(IEnumerable<TEntity> entities)
        {
            var enumerable = entities as TEntity[] ?? entities.ToArray();
            Context.Set<TEntity>().RemoveRange(enumerable);
            return await Task.FromResult(enumerable);
        }


        /// <summary>  
        /// Update the Entity  
        /// </summary>  
        /// <param name="entityToUpdate"></param>  
        public async Task UpdateEntity(TEntity entityToUpdate)
        {
            Entities.Attach(entityToUpdate);
            await Task.Run(() => Context.Entry(entityToUpdate).State = EntityState.Modified);
        }

        public async ValueTask<int> SaveChangesAsync() => await Context.SaveChangesAsync();
        
    }
}
