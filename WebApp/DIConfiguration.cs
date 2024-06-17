using Autofac;
using Autofac.Integration.Mvc;
using BLL.Repositories;
using BLL.Repositories.User;
using DataAccessLayer;
using FluentValidation;
using System.Web.UI;
using WebApp.Controllers;
using BLL.DTO.UserDTO;



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

            // Registering Validators
            RegisterValidators(builder);

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
        public static void RegisterValidators(ContainerBuilder builder) 
        {
			builder.RegisterAssemblyTypes(typeof(LoginModelValidator).Assembly)
		   .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
		   .AsImplementedInterfaces()
		   .InstancePerLifetimeScope();
		}
        
    }
}
