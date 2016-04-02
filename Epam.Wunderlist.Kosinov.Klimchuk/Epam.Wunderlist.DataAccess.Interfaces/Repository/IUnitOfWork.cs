using System;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IDbSession : IDisposable
    {
        void Commit();
    }
}