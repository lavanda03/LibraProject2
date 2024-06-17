
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Repositories.User;
using System.Security.Claims;



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

        [Authorize(Roles ="admin")]
		[AllowAnonymous]
		public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(BLL.DTO.UserDTO.GetUserDTO model)
        {
		    
			if (ModelState.IsValid) 
            {

                //var user = await serService.LoginUser(model.Login ,model.Password);
				var user = userRepository.LoginUser(model.Login, model.Password);

                var userClaim = new List<Claim>
                {
                    new Claim (ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim (ClaimTypes.Name ,user.Name),
                    new Claim ("Login" ,user.Login),
                    new Claim (ClaimTypes.Email,user.Email),
                    new Claim (ClaimTypes.Role,user.UserType),

                };


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaim, System.Web.Security.FormsAuthentication.FormsCookieName);
                var principal = new ClaimsPrincipal(claimsIdentity);

                System.Web.HttpContext.Current.User = principal;

				FormsAuthentication.SetAuthCookie("admin", false);
              

				return RedirectToAction("Index", "Home");

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