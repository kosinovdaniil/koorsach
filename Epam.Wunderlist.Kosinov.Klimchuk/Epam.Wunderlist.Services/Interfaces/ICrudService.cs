using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface ICrudService<IEntity>
    {
        IEntity Get(int id);

        IEnumerable<IEntity> GetAll();

        IEntity Create(IEntity entity);

        IEnumerable<IEntity> GetByPredicate(Expression<Func<IEntity, bool>> f);

        IEntity Update(IEntity entity);

        void Delete(IEntity entity);
    }
}
