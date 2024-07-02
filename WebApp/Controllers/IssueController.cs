using BBL.DTO.CommonDTO;
using BLL.DTO.IssueDTO;
using BLL.DTO.PosDTO;
using BLL.Repositories.Issue;
using BLL.Repositories.Pos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueRepository issueRepository;
        private readonly IPosRepository posRepository;


        public IssueController(IIssueRepository issueRepository,IPosRepository posRepository)
        {
            this.issueRepository = issueRepository;
            this.posRepository = posRepository;
        }

        [HttpGet]
        public ActionResult BrowsePos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateIssue(int id)
        {


            var viewModel = new PosAndIssuesViewModel
            {
                GetPosDTO = posRepository.GetPosById(id),  // Inițializare GetPosDTO sau folosește datele existente din logică
                AddIssuesDTO = new AddIssuesDTO() // Inițializare AddIssuesDTO sau folosește datele existente din logică
            };
			ViewBag.IssueType = issueRepository.GetAllIssuesType();
			return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateIssue(AddIssuesDTO issueModel)
        {
            ViewBag.IssueType = issueRepository.GetAllIssuesType();
            return View(issueModel);
        }

        [HttpGet]
        public ActionResult BrowseIssue()
        {

            return View();

        }

		[HttpGet]
		public JsonResult QueryPos()
		{
			var criteria = Request.GetPaginatingCriteria();

			var pos = posRepository.QueryPos(criteria);

			var jsonData = new
			{
				draw = Request.QueryString["draw"],
				recordTotal = pos.Total,
				recordsFiltered = pos.TotalFiltered,
				data = pos.PossDTO

			};

			return Json(jsonData, JsonRequestBehavior.AllowGet);
		}

		public JsonResult QueryIssue()
        {
            var criteria = Request.GetPaginatingCriteria();

            var issue = issueRepository.QueryIssue(criteria);

            var jsonData = new
            {
                draw = Request.QueryString["draw"],
                recordTotal = issue.Total,
                recordsFiltered = issue.TotalFiltered,
                data = issue.IssueDTO

            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}