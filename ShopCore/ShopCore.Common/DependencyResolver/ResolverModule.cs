using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Services;
using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DataAccess.MssqlProvider.Concrete;
using Epam.Wunderlist.DataAccess.MssqlProvider;
using Epam.Wunderlist.Services.Concrete;
using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.Common
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel);
        }

        private static void Configure(IKernel kernel)
        {

            kernel.Bind<IDbSession>().To<DbSession>().InRequestScope();
            kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();


            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IRepository<Item>>().To<ItemRepository>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ISignInService>().To<SignInService>();
            kernel.Bind<IOrderService>().To<OrderService>();

            kernel.Bind<ICrudService<Item>>().To<Service<Item>>();
            kernel.Bind<ICrudService<Order>>().To<OrderService>();
            kernel.Bind<ICrudService<User>>().To<UserService>();
        }
    }
}