using BBL.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthorityController : Controller
    {
      private readonly IUserService userService;
      public AuthorityController(IUserService userService)
      {
         this.userService= userService; 

      }


        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = userService.LoginUser(model.Login ,model.Password);

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
    }
}