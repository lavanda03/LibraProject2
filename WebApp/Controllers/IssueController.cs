using BLL.DTO.IssueDTO;
using BLL.DTO.UserDTO;
using BLL.Repositories.Issue;
using BLL.Repositories.Pos;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Helpers;
using BLL.DTO.IssueDTO.IssueValidation;
using FluentValidation.Results;


namespace WebApp.Controllers
{
	public class IssueController : Controller
	{
		private readonly IIssueRepository issueRepository;
		private readonly IPosRepository posRepository;


		public IssueController(IIssueRepository issueRepository, IPosRepository posRepository)
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

			var model = new AddIssuesDTO
			{
				IdPos = id,
				PosName = posModel.Name,
				PosTelephone = posModel.Telephone,
				PosCellPhone = posModel.CellPhone,
				PosAddress = posModel.Address
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult CreateIssue(AddIssuesDTO issueModel)
		{
			IssueValidation issueValidation = new IssueValidation(issueRepository);
			ValidationResult result = issueValidation.Validate(issueModel);

			if (ModelState.IsValid)
			{
				HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
				FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
				var user = JsonConvert.DeserializeObject<GetUserDTO>(authTicket.UserData);

				issueModel.IdUserCreated = user.Id;
				issueModel.IdUserType = user.UserTypeId;

				issueRepository.AddIssue(issueModel);
				return RedirectToAction("BrowseIssue");
			}
			else
			{
				foreach (var failure in result.Errors)
				{
					ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
				}
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
				recordsTotal = pos.Total,
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
				recordsTotal = issue.Total,
				recordsFiltered = issue.TotalFiltered,
				data = issue.IssueDTO

			};

			return Json(jsonData, JsonRequestBehavior.AllowGet);
		}

		public JsonResult QueryLogs()
		{
			var criteria = Request.GetPaginatingCriteria();

			var log = issueRepository.QueryLogs(criteria);

			var jsonData = new
			{
				draw = Request.QueryString["draw"],
				recordsTotal = log.Total,
				recordsFiltered = log.TotalFiltered,
				data = log.Logs


			};

			return Json(jsonData, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult EditIssue(UpdateIssuesDTO updateIssues)
		{
			var issueTypes = issueRepository.GetAllIssuesType();
			ViewBag.IssueType = issueTypes.Where(x => x.IssueLevel == 1).ToList();
			ViewBag.SubType = issueTypes.Where(x => x.IssueLevel == 2).ToList();
			ViewBag.ProblemType = issueTypes.Where(x => x.IssueLevel == 3).ToList();
			ViewBag.Priority = issueRepository.GetPriority();
			ViewBag.Status = issueRepository.GetStatuses();
			ViewBag.UserType = issueRepository.GetUserType();

			if (ModelState.IsValid)
			{
				issueRepository.UpdateIssue(updateIssues);
				return RedirectToAction("BrowseIssue");
			}
			return View("_EditIssuePartialView");
		}

		[HttpGet]
		public ActionResult EditIssuePartialView(int issueId)
		{
			var issueTypes = issueRepository.GetAllIssuesType();
			ViewBag.IssueType = issueTypes.Where(x => x.IssueLevel == 1).ToList();
			ViewBag.SubType = issueTypes.Where(x => x.IssueLevel == 2).ToList();
			ViewBag.ProblemType = issueTypes.Where(x => x.IssueLevel == 3).ToList();
			ViewBag.Priority = issueRepository.GetPriority();
			ViewBag.Status = issueRepository.GetStatuses();
			ViewBag.UserType = issueRepository.GetUserType();

			var issue = issueRepository.GetIssueById(issueId);

			var updateIssueDTO = new UpdateIssuesDTO
			{
				Id = issue.Id,
				IdPos = issue.IdPos,
				PosName = issue.PosName,
				IdType = issue.IdType,
				IdSubType = issue.IdSubType,
				IdProblem = issue.IdProblem,
				IdStatus = issue.IdStatus,
				PriorityId = issue.PriorityId,
				Solution = issue.Solution,
				Memo = issue.Memo,
				IdUserCreated = issue.IdUserCreated,
				IdUserType = issue.IdUserType,
				ProblemDescription = issue.ProblemDescription,
				PosTelephone = issue.PosTelephone,
				PosCellPhone = issue.PosCellPhone,
				PosAddress = issue.PosAddress,
			};

			return View("_EditIssuePartialView", updateIssueDTO);
		}

		[HttpGet]
		public ActionResult DetailsIssuePartialView(int issueId)
		{
			var issueTypes = issueRepository.GetAllIssuesType();
			ViewBag.IssueType = issueTypes.Where(x => x.IssueLevel == 1).ToList();
			ViewBag.SubType = issueTypes.Where(x => x.IssueLevel == 2).ToList();
			ViewBag.ProblemType = issueTypes.Where(x => x.IssueLevel == 3).ToList();
			ViewBag.Priority = issueRepository.GetPriority();
			ViewBag.Status = issueRepository.GetStatuses();
			ViewBag.UserType = issueRepository.GetUserType();

			var issue = issueRepository.GetIssueById(issueId);

			return View("_DetailsIssuePartialView", issue);
		}
	}
}