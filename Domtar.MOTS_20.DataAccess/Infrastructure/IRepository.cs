using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Domtar.MOTS_20.DataAccess.Infrastructure
{
    public interface IRepository<TDataType> where TDataType : class
    {
        // Marks an entity as new
        TDataType Add([NotNull] TDataType entity);

        IEnumerable<TDataType> AddRange([NotNull] IEnumerable<TDataType> entity);
        // Marks an entity as modified
        void Update([NotNull] TDataType entity);
        // Marks an entity to be removed
        void Delete([NotNull] TDataType entity);
        void Delete([NotNull] Expression<Func<TDataType, bool>> whereFunc);

        /// <summary>
        /// Saves any changes made to tracked entities.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Saves any changes made to tracked entities.
        /// </summary>
        /// <param name="ct"></param>
        Task SaveChangesAsync(CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Attempts to find a <see cref="TDataType"/> entry with the provided Id.
        /// </summary>
        /// <param name="id">The Id to search for.</param>
        /// <returns>Returns the matching <see cref="TDataType"/> entry if there is one, otherwise return null.</returns>
        [CanBeNull]
        TDataType GetById(int id);

        /// <summary>
        /// Attempts to find a <see cref="TDataType"/> entry with the provided Id.
        /// </summary>
        /// <param name="id">The Id to search for.</param>
        /// <param name="ct"></param>
        /// <returns>Returns the matching <see cref="TDataType"/> entry if there is one, otherwise return null.</returns>
        [NotNull]
        [ItemCanBeNull]
        Task<TDataType> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Attempts to find a single <see cref="TDataType"/> entry selected by the provided <paramref name="whereFunc"/> delegate.
        /// </summary>
        /// <param name="whereFunc"></param>
        /// <returns>Returns the matching <see cref="TDataType"/> entry if there is one, otherwise return null.</returns>
        [CanBeNull]
        TDataType Get([NotNull] Expression<Func<TDataType, bool>> whereFunc);

        /// <summary>
        /// Attempts to find a single <see cref="TDataType"/> entry selected by the provided <paramref name="whereFunc"/> delegate.
        /// </summary>
        /// <param name="whereFunc"></param>
        /// <param name="ct"></param>
        /// <returns>Returns the matching <see cref="TDataType"/> entry if there is one, otherwise return null.</returns>
        [NotNull]
        [ItemCanBeNull]
        Task<TDataType> GetAsync([NotNull] Expression<Func<TDataType, bool>> whereFunc, CancellationToken ct = default(CancellationToken));

        // Gets all entities of type T
        [NotNull]
        IQueryable<TDataType> GetAll();

        // Gets entities using delegate
        [NotNull]
        IQueryable<TDataType> GetMany(Expression<Func<TDataType, bool>> whereFunc);
    }
}
