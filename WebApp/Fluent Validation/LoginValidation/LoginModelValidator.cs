using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BLL.Repositories.User;
using FluentValidation;
using WebApp.Models;

namespace WebApp.Fluent_Validation.LoginValidation
{
	public class LoginModelValidator:AbstractValidator<LoginModel>
	{
		private readonly IUserRepository _userRepository;
		 
		public LoginModelValidator(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		   //	RuleFor(x => x.Login).NotNull();
			//RuleFor(x => x.Password).NotNull();

			//RuleFor(x => x.Login).NotEmpty().Must(_userRepository.ExistLogin).WithMessage("Don't exist user with this login");
		}

	}


}