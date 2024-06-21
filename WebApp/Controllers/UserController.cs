using BBL.DTO.UserDTO.UserValidation;
using BLL.DTO.UserDTO;
using BLL.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
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
		public ActionResult Browse()
        {
			var users = userRepository.GetAllUsers();
            return View(users);
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
			if (!ModelState.IsValid)
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

				var user = userRepository.AddUser(model);

				if (user == null)
				{

					ModelState.AddModelError("", "Invalid login attempt");
					return View(model);
				}
			}

			ViewBag.UserTypes = userRepository.GetAllUsersType();
			return View(model);
		}

    }
}