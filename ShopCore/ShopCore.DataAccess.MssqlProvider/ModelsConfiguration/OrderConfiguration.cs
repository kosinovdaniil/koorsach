using ShopCore.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace ShopCore.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasMany(x => x.Items).WithRequired(x => x.List);
        }
    }
}
