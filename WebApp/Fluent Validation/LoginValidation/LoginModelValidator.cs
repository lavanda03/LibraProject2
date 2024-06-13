using FluentValidation;
using WebApp.Models;

namespace WebApp.Fluent_Validation.LoginValidation
{
    public class LoginModelValidator:AbstractValidator<LoginModel>
	{
		public LoginModelValidator()
		{

			RuleFor(x => x.Login).NotNull().WithMessage("test login error");
			RuleFor(x => x.Password).NotNull().WithMessage("test password error");
		}		
	}

}