using ShopCore.DomainModel;

namespace ShopCore.DataAccess.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByMail(string mail);
    }
}
