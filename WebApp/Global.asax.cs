using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = DIConfiguration.Configure();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
