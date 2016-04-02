using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using System.Data.Entity;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public class DbSession : IDbSession
    {
        public DbContext Context { get; private set; }

        public DbSession(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}