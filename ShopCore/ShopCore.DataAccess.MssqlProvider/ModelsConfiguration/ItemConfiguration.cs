using ShopCore.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace ShopCore.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
        }
    }
}
