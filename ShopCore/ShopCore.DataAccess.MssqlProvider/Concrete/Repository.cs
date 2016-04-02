using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        #region Fields

        protected readonly DbContext _context;

        #endregion

        #region Constructors

        protected Repository(DbContext context)
        {
            this._context = context;
        }
        #endregion

        #region Methods
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(item => item.Id == id);
            return entity;
        }

        public virtual IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> f)
        {
            return _context.Set<TEntity>().Where(f);
        }

        public virtual TEntity Create(TEntity entity)
        {
            var elem = _context.Set<TEntity>().Add(entity);
            return elem;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //var elem = _context.Set<TEntity>().FirstOrDefault(item => item.Id == entity.Id);
            //if (elem == null)
            //{
            //    return;
            //}
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var elem = _context.Set<TEntity>().FirstOrDefault(item => item.Id == entity.Id);
            CopyEntityFields(entity, elem);
            return elem;
        }
        #endregion

        #region Protected methods
        protected abstract void CopyEntityFields(TEntity source, TEntity target);
        #endregion
    }
}
