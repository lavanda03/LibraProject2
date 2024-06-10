using BBL.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Authorize]
	public class AuthorityController : Controller
    {
      private readonly IUserService userService;
      public AuthorityController(IUserService userService)
      {
         this.userService= userService; 

      }

		[AllowAnonymous]
		public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid) 
            {
                //var user = await serService.LoginUser(model.Login ,model.Password);
				var user = userService.LoginUser(model.Login, model.Password);
           
				if (user != null) 
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
					ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
				}

            }
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authority");
        }
    }
}