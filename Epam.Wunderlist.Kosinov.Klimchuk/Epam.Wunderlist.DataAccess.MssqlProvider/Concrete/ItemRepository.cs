using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public class ItemRepository : Repository<Item>
    {
        #region Constructor
        public ItemRepository(DbContext context)
            : base(context)
        { }
        #endregion

        #region Protected methods
        protected override void CopyEntityFields(Item source, Item target)
        {
            target.Name = source.Name ?? target.Name;
            target.Description = source.Description ?? target.Description;
            target.Price = source.Price == 0 ? target.Price : source.Price;
            target.Quantity = source.Quantity ?? target.Quantity;
        }
        #endregion
    }
}