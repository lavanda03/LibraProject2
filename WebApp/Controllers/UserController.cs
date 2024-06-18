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

		public UserController(IUserRepository userRepository)
		{

			this.userRepository = userRepository;
		}

		// GET: User
		public ActionResult Browse()
        {
			var users = userRepository.GetAllUsers();
            return View(users);
        }
    }
}