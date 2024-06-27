using BBL.DTO.UserDTO.UserValidation;
using BLL.DTO.UserDTO;
using BLL.Repositories.User;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using WebApp.Helpers;

namespace WebApp.Controllers
{
	[Authorize]
	public class UserController : Controller
    {

		private readonly IUserRepository userRepository;
		private readonly AddUserValidation validation;

		public UserController(IUserRepository userRepository,AddUserValidation validation)
		{
		
			this.userRepository = userRepository;
			this.validation = validation;
		}

		// GET: User
		[HttpGet]
		public ActionResult Browse()
        {
            return View();
        }

		[HttpGet]
		public JsonResult QueryUsers()
		{
			var criteria = Request.GetPaginatingCriteria();

			var users = userRepository.QueryUsers(criteria);

			var jsonData = new
			{
				draw = Request.QueryString["draw"],
				recordsTotal = users.Total,
				recordsFiltered = users.TotalFiltered,
				data = users.UserDTO
			};

			return Json(jsonData, JsonRequestBehavior.AllowGet);
		}


		[HttpGet]
		public ActionResult CreateUser()
	{
			ViewBag.UserTypes = userRepository.GetAllUsersType();
			return View();
		}
		[HttpPost]	
		public ActionResult CreateUser(AddUserDTO model)
		{
			if (ModelState.IsValid)
			{
				var result = validation.Validate(model);

				if (!result.IsValid)
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					}
					ViewBag.UserTypes = userRepository.GetAllUsersType();
					return View(model);
				}

				userRepository.AddUser(model);

				return RedirectToAction("Browse");
			}

			ViewBag.UserTypes = userRepository.GetAllUsersType();
			return View(model);
		}

		[HttpGet]
		public ActionResult DetailsUser(int id)
		{
			var user = userRepository.GetUserById(id);

			if (user == null)
			{
				return HttpNotFound();
			}
			return View(user);
		}

    }
}