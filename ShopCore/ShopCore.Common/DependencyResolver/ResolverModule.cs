using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using ShopCore.Services.Interfaces;
using ShopCore.Services.Services;
using ShopCore.DataAccess.Interfaces.Repository;
using ShopCore.DataAccess.MssqlProvider.Concrete;
using ShopCore.DataAccess.MssqlProvider;
using ShopCore.Services.Concrete;
using ShopCore.DomainModel;

namespace ShopCore.Common
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
