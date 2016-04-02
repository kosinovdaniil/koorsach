using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using System.Data.Entity;
using System.Linq;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructor
        public UserRepository(DbContext context)
            : base(context) { }
        #endregion

        #region Methods
        public User GetByMail(string mail)
        {
            var user = _context.Set<User>().FirstOrDefault(item => item.Email == mail);
            return user;
        }
        #endregion

        #region Protected methods
        protected override void CopyEntityFields(User source, User target)
        {
            target.Name = source.Name ?? target.Name;
            target.PhotoPath = source.PhotoPath ?? target.PhotoPath;
        }
        #endregion
    }
}