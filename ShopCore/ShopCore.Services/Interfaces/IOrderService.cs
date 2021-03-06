using ShopCore.DomainModel;
using System.Collections.Generic;

namespace ShopCore.Services.Interfaces
{
    public interface IOrderService : ICrudService<Order>
    {
        IEnumerable<Order> GetByUser(int id);
    }
}
