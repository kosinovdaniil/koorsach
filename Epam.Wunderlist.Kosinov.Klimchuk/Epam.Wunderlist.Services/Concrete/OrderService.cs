using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Services
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