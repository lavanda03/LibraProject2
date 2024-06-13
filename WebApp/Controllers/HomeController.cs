
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		

        public HomeController()
        {  
        }

        public ActionResult Index()
		{
			return View();
		}

		[Authorize]
		public ActionResult About()
		{
			ViewBag.Message = "Welcome back.";

			return View();
		}

		[Authorize]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}