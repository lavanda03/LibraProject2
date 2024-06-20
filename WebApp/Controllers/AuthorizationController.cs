
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Repositories.User;
using System.Security.Claims;
using BLL.DTO.UserDTO;
using Newtonsoft.Json;



namespace WebApp.Controllers
{
	[Authorize]
	public class AuthorizationController : Controller
    {
     
       private readonly IUserRepository userRepository;
    
        public AuthorizationController(IUserRepository userRepository)
		{ 
           this.userRepository = userRepository;
        }

		[AllowAnonymous]
		public ActionResult Login()
        {
            return View();
        }


		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Login(BLL.DTO.UserDTO.GetUserDTO model)
		{

			if (ModelState.IsValid)
			{

				var user = userRepository.LoginUser(model.Login, model.Password);

				if (user == null)
				{
					ModelState.AddModelError("login", "not valid user");
					
				}

				else
				{
					string userData = JsonConvert.SerializeObject(user);

					var authTicket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddDays(15), false, userData);

					string encTicket = FormsAuthentication.Encrypt(authTicket);
					var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
					Response.Cookies.Add(faCookie);

					return RedirectToAction("Index", "Home");

				}
			}
			return View(model);
		}


		[HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authorization");
        }
    }
}