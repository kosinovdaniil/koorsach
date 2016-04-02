using Epam.Wunderlist.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int key);

        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> f);

        TEntity Create(TEntity e);

        void Delete(TEntity e);

        TEntity Update(TEntity entity);
    }
}