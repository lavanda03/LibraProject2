using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;
using WebApp.Fluent_Validation.LoginValidation;

namespace WebApp.Models
{

	[FluentValidation.Attributes.Validator(typeof(LoginModelValidator))]
	public class LoginModel
	{
	    public LoginModel() { }
		public string Login { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}