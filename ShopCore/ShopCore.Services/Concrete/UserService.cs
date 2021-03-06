using ShopCore.DataAccess.Interfaces.Repository;
using ShopCore.DomainModel;
using ShopCore.Services.Interfaces;
using ShopCore.Services.Services;
using System;
using CryptSharp;

namespace ShopCore.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        #region Constructor
        public UserService(IDbSession dbSession, IUserRepository repository)
            : base(dbSession, repository)
        { }
        #endregion

        #region Methods
        public User ValidateUser(string email, string password)
        {
            var user = ((IUserRepository)_repository).GetByMail(email);
            if (user == null)
                return null;
            if (BlowfishCrypter.CheckPassword(password, user.Password))
                return user;
            return null;
        }

        public User Get(string mail)
        {
            if (mail == null)
            {
                throw new ArgumentNullException("mail");
            }
            return ((IUserRepository)_repository).GetByMail(mail);
        }
        #endregion
    }
}
