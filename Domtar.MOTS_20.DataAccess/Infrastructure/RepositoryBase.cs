using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Domtar.MOTS_20.DataAccess.Infrastructure
{
    public abstract class RepositoryBase<TDataType> : IRepository<TDataType> where TDataType : class
    {
        #region Fields

        private MOTS_20Entities _dataContext;
        private readonly DbSet<TDataType> _dbSet;

        #endregion

        #region Properties

        protected IDbFactory DbFactory { get; }
        protected IUnitOfWork UnitOfWork { get; }

        protected MOTS_20Entities DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        #endregion

        protected RepositoryBase(IDbFactory dbFactory, IUnitOfWork unitOfWork)
        {
            DbFactory = dbFactory;
            UnitOfWork = unitOfWork;
            _dbSet = DbContext.Set<TDataType>();
        }

        #region Implementation
        public virtual TDataType Add(TDataType entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            return _dbSet.Add(entity);
        }

        public virtual IEnumerable<TDataType> AddRange(IEnumerable<TDataType> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            return _dbSet.AddRange(entity);
        }

        public virtual void Update(TDataType entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TDataType entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TDataType, bool>> whereFunc)
        {
            if (whereFunc == null) throw new ArgumentNullException(nameof(whereFunc));
            var objects = _dbSet.Where(whereFunc);
            foreach (var obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual void SaveChanges()
        {
            _dataContext.SaveChanges();
            UnitOfWork.Commit();
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken))
        {
            await _dataContext.SaveChangesAsync(cancellationToken);
            UnitOfWork.Commit();
        }

        public virtual TDataType GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TDataType> GetByIdAsync(int id, CancellationToken ct = default (CancellationToken))
        {
            return await _dbSet.FindAsync(ct, id);
        }

        public virtual IQueryable<TDataType> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<TDataType> GetMany([NotNull] Expression<Func<TDataType, bool>> whereFunc)
        {
            if (whereFunc == null) throw new ArgumentNullException(nameof(whereFunc));
            return _dbSet.Where(whereFunc);
        }

        public TDataType Get(Expression<Func<TDataType, bool>> whereFunc)
        {
            if (whereFunc == null) throw new ArgumentNullException(nameof(whereFunc));
            return _dbSet.Where(whereFunc).FirstOrDefault();
        }

        public async Task<TDataType> GetAsync(Expression<Func<TDataType, bool>> whereFunc, CancellationToken ct = default(CancellationToken))
        {
            if (whereFunc == null) throw new ArgumentNullException(nameof(whereFunc));
            return await _dbSet.Where(whereFunc).FirstOrDefaultAsync(ct);
        }

        #endregion

    }
}
