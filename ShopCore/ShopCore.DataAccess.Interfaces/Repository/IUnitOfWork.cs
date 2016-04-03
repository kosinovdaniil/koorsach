using System;

namespace ShopCore.DataAccess.Interfaces.Repository
{
    public interface IDbSession : IDisposable
    {
        void Commit();
    }
}
