using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByMail(string mail);
    }
}