using Epam.Wunderlist.DomainModel;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IOrderService : ICrudService<Order>
    {
        IEnumerable<Order> GetByUser(int id);
    }
}
