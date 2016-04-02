using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IUserService : ICrudService<User>
    {
        User Get(string mail);

        User ValidateUser(string email, string password);
    }
}
