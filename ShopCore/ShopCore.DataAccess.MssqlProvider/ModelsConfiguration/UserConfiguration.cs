using ShopCore.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace ShopCore.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(x => x.Lists).WithMany(x => x.Users);
        }
    }
}
