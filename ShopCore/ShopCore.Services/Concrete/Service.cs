using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CryptSharp;

namespace Epam.Wunderlist.Services.Services
{
    public abstract class Service<TEntity> : ICrudService<TEntity>
        where TEntity : Entity
    {
        #region Fields
        protected readonly IDbSession _dbSession;
        protected readonly IRepository<TEntity> _repository;
        #endregion

        #region Constructor
        protected Service(IDbSession dbSession, IRepository<TEntity> repository)
        {
            this._dbSession = dbSession;
            this._repository = repository;
        }
        #endregion

        #region Methods
        public TEntity Create(TEntity entity)
        {
            if (entity == null)                            
            {
                throw new ArgumentNullException("entity");
            }
            var user = entity as User;
            if (user != null)
            {
                user.Password = BlowfishCrypter.Blowfish.Crypt(user.Password);
            }
            var result = _repository.Create(entity);
            if (result != null)
                _dbSession.Commit();

            return result;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Delete(entity);
            _dbSession.Commit();
        }

        public TEntity Get(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var temp = _repository.Update(entity);
            _dbSession.Commit();
            return temp;
        }

        public virtual IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> f)
        {
            return _repository.GetByPredicate(f);
        }
        #endregion
    }
}
