using ShopCore.DomainModel;

namespace ShopCore.Services.Interfaces
{
    public interface ISignInService
    {
        void IdentitySignin(User user, bool isPersistent = false);       

        void IdentitySignout();
    }
}
