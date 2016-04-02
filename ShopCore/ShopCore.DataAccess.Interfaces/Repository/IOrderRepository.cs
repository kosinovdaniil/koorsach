using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByUser(int id);
    }
}
