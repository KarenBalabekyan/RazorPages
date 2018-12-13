using Microsoft.EntityFrameworkCore;
using SimpleStore.DataAccess.DbContexts;
using SimpleStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }


        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }


        public virtual async Task<int> CreateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbSet.AddAsync(entity);
            var id = await Save(cancellationToken);

            return id;
        }

        public virtual async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            var createRange = entities as T[] ?? entities.ToArray();
            await _dbSet.AddRangeAsync(createRange);
            await Save(cancellationToken);
            return createRange;
        }


        public virtual async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Update(entity);
            var id = await Save(cancellationToken);
            return id;
        }

        public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            var updateRange = entities as T[] ?? entities.ToArray();
            _dbSet.UpdateRange(updateRange);
            await Save(cancellationToken);
            return updateRange;
        }


        public virtual async Task<int> RemoveAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
            return await Save(cancellationToken);
        }

        public virtual async Task<int> RemoveByIdAsync(object entityId, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> RemoveByRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            var romoveRange = entities as T[] ?? entities.ToArray();
            _dbSet.RemoveRange(romoveRange);

            return await Save(cancellationToken);
        }


        public virtual async Task<int> Save(CancellationToken cancellationToken)
        {
            var id = 0;

            try
            {
                id = await _context.SaveChangesAsync(default(CancellationToken));
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }
    }
}
