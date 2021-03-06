using ShopCore.DataAccess.Interfaces.Repository;
using ShopCore.DomainModel;
using ShopCore.Services.Interfaces;
using System.Collections.Generic;

namespace ShopCore.Services.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        #region Constructor
        public OrderService(IDbSession dbSession, IOrderRepository repository)
            : base(dbSession, repository) { }
        #endregion

        #region Methods
        public IEnumerable<Order> GetByUser(int id)
        {
            return ((IOrderRepository)_repository).GetByUser(id);
        }
        #endregion
    }
}
