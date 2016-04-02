using Epam.Wunderlist.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasMany(x => x.Items).WithRequired(x => x.List);
        }
    }
}
