using ShopCore.DomainModel;
using System.Collections.Generic;

namespace ShopCore.DataAccess.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByUser(int id);
    }
}
