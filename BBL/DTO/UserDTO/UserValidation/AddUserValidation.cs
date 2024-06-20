using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.UserDTO;
using BLL.Repositories.User;
using FluentValidation;

namespace BBL.DTO.UserDTO.UserValidation
{
	public class AddUserValidation : AbstractValidator<AddUserDTO>
	{
		public AddUserValidation()
		{
			RuleFor(user => user.Login)
			.NotEmpty().WithMessage("Login is required.");
			//.Must(login => userRepository.ExistLogin(login))
			//.WithMessage("Login already exists.");

			RuleFor(x => x.Password).NotNull().WithMessage(" Password is required");

			RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Invalid email format.");

			RuleFor(x => x.Telephone)
				.NotEmpty().WithMessage("Phone number is required.")
				.Matches(@"^\+[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

			RuleFor(x => x.Name	).NotEmpty().WithMessage("Please specify a  name");
			RuleFor(x => x.UserTypeId).NotEmpty().WithMessage("Please specify a user type");
		}
	}

	
}
