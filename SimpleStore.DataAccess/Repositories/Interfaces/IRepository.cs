using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Repositories.Interfaces
{
    //http://techbrij.com/generic-repository-unit-of-work-entity-framework-unit-testing-asp-net-mvc
    public interface IRepository<T> where T : class //where section can be deleted
    {
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<int> CreateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> RemoveAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> RemoveByRangeAsync(IEnumerable<T> entities,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<int> RemoveByIdAsync(object entityId, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> Save(CancellationToken cancellationToken = default(CancellationToken));
    }
}