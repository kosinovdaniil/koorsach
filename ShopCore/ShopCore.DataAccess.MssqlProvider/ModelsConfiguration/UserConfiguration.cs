using Epam.Wunderlist.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(x => x.Lists).WithMany(x => x.Users);
        }
    }
}
