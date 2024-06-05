using Autofac;
using Autofac.Integration.Mvc;
using BBL.Repositories;
using BBL.Repositories.User;
using BBL.Services.User;
using DataAccessLayer;
using WebApp.Controllers;


namespace WebApp
{
    public static class DIConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Register DbContext
            builder.Register(c =>
            {
                return new ApplicationDbContext();
            }).SingleInstance();

            // Registering Repositories 
            RegisterRepositories(builder);

            // Registering Services
            RegisterServices(builder);

            // Registering Controllers
            RegisterControllers(builder);

            return builder.Build();
        }

        public static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }

        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
        }

        public static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(HomeController).Assembly);
        }
    }
}
