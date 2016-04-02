using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        #region Constructor
        public OrderRepository(DbContext context)
            : base(context)
        { }
        #endregion

        #region Methods
        public override Order Create(Order entity)
        {
            entity.User = _context.Set<User>().FirstOrDefault(user => entity.User.Id == user.Id);
            if (entity.User == null)
            {
                throw new ArgumentException();
            }
            return base.Create(entity);
        }

        public IEnumerable<Order> GetByUser(int id)
        {
            var orders = GetByPredicate(order => order.User.Id == id);
            return orders;
        }
        #endregion

        #region Protected methods
        protected override void CopyEntityFields(Order source, Order target)
        {
            //target.Name = source.Name ?? target.Name;
        }
        #endregion
    }
}