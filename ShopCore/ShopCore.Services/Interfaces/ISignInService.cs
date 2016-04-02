using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface ISignInService
    {
        void IdentitySignin(User user, bool isPersistent = false);       

        void IdentitySignout();
    }
}
