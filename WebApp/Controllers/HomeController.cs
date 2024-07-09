
using BLL.Repositories.Issue;
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
		private readonly IIssueRepository issueRepository;

		public HomeController(IIssueRepository issueRepository)
        {
			this.issueRepository = issueRepository;
        }

		[Authorize()]
		[HttpGet]
        public ActionResult Index()
		{
			var issue = issueRepository.GetAllIssues();
			var result = issue.GroupBy(x => x.Status).Select(x => new { Status = x.Key, Count = x.Count() }).ToList();
			ViewBag.Status = result;


			return View(result);
			
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