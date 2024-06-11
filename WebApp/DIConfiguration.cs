using Autofac;
using Autofac.Integration.Mvc;
using BLL.Repositories;
using BLL.Repositories.User;
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
           

            // Registering Controllers
            RegisterControllers(builder);

            return builder.Build();
        }

        public static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }


        public static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(HomeController).Assembly);
        }
        
    }
}
