
using BLL.DTO.IssueDTO;
using BLL.DTO.PosDTO;
using BLL.DTO.UserDTO;
using BLL.Repositories.Issue;
using BLL.Repositories.Pos;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

			var posModel = posRepository.GetPosById(id);

			ViewBag.IssueType = issueRepository.GetAllIssuesType();
			ViewBag.Priority = issueRepository.GetPriority();
			ViewBag.Status = issueRepository.GetStatuses();

			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
			var user = JsonConvert.DeserializeObject<GetUserDTO>(authTicket.UserData);

			var model = new AddIssuesDTO
			{
				IdUserCreated = user.Id,
				IdUserType = user.UserTypeId,
				IdPos = id
			};

			// Adaugă modelul POS în ViewBag
			ViewBag.PosModel = posModel;

			return View(model);
		}

        [HttpPost]
        public ActionResult CreateIssue(AddIssuesDTO issueModel)
        {
			

			if (ModelState.IsValid)
			{
                issueRepository.AddIssue(issueModel);
				return RedirectToAction("BrowsePos");
			}


			ViewBag.IssueType = issueRepository.GetAllIssuesType();
            return View();
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