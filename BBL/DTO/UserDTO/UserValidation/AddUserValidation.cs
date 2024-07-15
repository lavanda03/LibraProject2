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
		private readonly IUserRepository _userRepository;
		public AddUserValidation(IUserRepository userRepository)
		{
			_userRepository = userRepository;

			RuleFor(user => user.Login)
			   .NotEmpty().WithMessage("Login is required.")
			   .Must(_userRepository.ExistLogin).WithMessage("Login must be unique");

			RuleFor(x => x.Password).NotEmpty().WithMessage(" Password is required");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("Invalid email format.")
				.Must(_userRepository.ExistUserByEmail).WithMessage("Email must be unique");


			RuleFor(x => x.Telephone)
				.NotEmpty().WithMessage("Phone number is required.")
				.MinimumLength(9).WithMessage("Number is too short")
				.Matches(@"^\d{9}$").WithMessage("Phone number must be exactly 9 digits.")
				.Must(_userRepository.ExistTelephone).WithMessage("Telephone must be unique");


			RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a  name");
			RuleFor(x => x.UserTypeId).NotEmpty().WithMessage("Please specify a user type");
		}
	}


}
