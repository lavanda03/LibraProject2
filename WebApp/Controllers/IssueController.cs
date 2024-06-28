using BLL.DTO.IssueDTO;
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


        public IssueController(IIssueRepository issueRepository)
        {
            this.issueRepository = issueRepository;
        }

        [HttpGet]
        public ActionResult CreateIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateIssue(AddIssuesDTO issueModel)
        {
            return View(issueModel);
        }

        [HttpGet]
        public ActionResult BrowseIssue()
        {

            return View();

        }


        public JsonResult QuerryIssue()
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