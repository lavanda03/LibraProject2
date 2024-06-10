using BBL.Repositories;
using BBL.Repositories.User;
using BBL.Services.User.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace BBL.Services.User
{
    public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
        {
			this.userRepository = userRepository;
        }

		public bool IsValidEmail(string emailAddress)
		{
			var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

			var regex = new Regex(pattern);
			return regex.IsMatch(emailAddress);
		}

		private bool IsValidPhone(string phoneNumber)
		{
			foreach (char digit in phoneNumber)
			{
				if (!char.IsDigit(digit) && !char.IsSymbol('+'))
				{
					return false;
				}
			}

			return true;
		}

		public int AddUser(AddUserCommand command)
		{
			if (string.IsNullOrEmpty(command.Name))
				throw new Exception(ErrorHandlerService.ParameterNotValidError("Name"));

			if (IsValidEmail(command.Email) || string.IsNullOrEmpty(command.Email))
				throw new Exception(ErrorHandlerService.ParameterNotValidError("Email"));

			if (string.IsNullOrEmpty(command.Password))
				throw new Exception(ErrorHandlerService.ParameterNotValidError("Password"));

			if (userRepository.ExistUserByEmail(command.Email))
				throw new Exception(ErrorHandlerService.ParameterAlreadyExistsError("Email"));

			if (!IsValidPhone(command.Telephone))
			{
				throw new Exception(ErrorHandlerService.ParameterMustHaveError("Phone", new[] { "digits" }));
			}

			var userEntity = userRepository.AddUser(new UserEntity
			{
				Name = command.Name,
				Email = command.Email,
				Password = command.Password,
				Login = command.Login,
				Telephone = command.Telephone,
				UserTypeId = command.UserTypeId
			});
			return userEntity;
		}

		public List <GetUserResult>GetAllUsers()
		{
			var result= new List<GetUserResult>();
			var userEntity=userRepository.GetAllUsers();

            foreach (var c in userEntity)
            {
				result.Add(new GetUserResult()
				{
				 
					Name= c.Name,		
					Email= c.Email,	
					Login= c.Login,
					Telephone=c.Telephone,
					UserTypeId = c.UserTypeId
					
				});
            }
			return result;
        }

		public GetUserResult GetUserById(int id) 
		{
			if (id <= 0)
				throw new Exception(ErrorHandlerService.ParameterNotValidError("User Id"));

			var userEntity = userRepository.GetUserById(id);

			if (userEntity == null)
				throw new Exception(ErrorHandlerService.ParameterNotFoundError("User"));


			var result = new GetUserResult()
			{
				Id= userEntity.Id,
				Name = userEntity.Name,
				Email = userEntity.Email,
				Login = userEntity.Login,
				Telephone = userEntity.Telephone,
				UserTypeId = userEntity.UserTypeId	
			};
			return result;
		}

		public void UpdateUser(UpdateUserCommand command)
		{
			if (command.Id <= 0)
				throw new Exception(ErrorHandlerService.ParameterNotValidError("User Id"));

			if (string.IsNullOrEmpty(command.Name))
				throw new Exception(ErrorHandlerService.ParameterNotValidError("Name"));

			if (IsValidEmail(command.Email) || string.IsNullOrEmpty(command.Email))
				throw new Exception(ErrorHandlerService.ParameterNotValidError("Email"));

			if (userRepository.ExistUserByEmail(command.Email))
				throw new Exception(ErrorHandlerService.ParameterAlreadyExistsError("Email"));

			if (!IsValidPhone(command.Telephone))
			{
				throw new Exception(ErrorHandlerService.ParameterMustHaveError("Phone", new[] { "digits" }));
			}

			var userEntity = userRepository.GetUserById(command.Id);

			if (userEntity == null)
				throw new Exception(ErrorHandlerService.ParameterNotFoundError("User"));

			if (command.Name!= userEntity.Name)
			   userEntity.Name = command.Name;

			if (command.Telephone!= userEntity.Telephone)
				userEntity.Telephone = command.Telephone;

			if (command.Email != userEntity.Email)
				userEntity.Email = command.Email;

			if (command.IdUserType != userEntity.UserTypeId)
				userEntity.UserTypeId = command.IdUserType;


			userRepository.UpdateUser(userEntity);
		}

		public void DeleteUser(int id) 
		{
			if (id <= 0)
				throw new Exception(ErrorHandlerService.ParameterNotValidError("User Id"));

			var userEntity = userRepository.GetUserById(id);

			if (userEntity == null)
				throw new Exception(ErrorHandlerService.ParameterNotFoundError("User"));

			userRepository.DeleteUser(userEntity.Id);
		}

		public GetUserResult LoginUser(string Login, string password)
		{
			var userResult = userRepository.LoginUser(Login, password);

			if (userResult == null)
			{
				return null;
			}
			var result = new GetUserResult()
			{

				Id = userResult.Id,
				Name = userResult.Name,
				Email = userResult.Email,
				Login = userResult.Login,
				UserTypeId = userResult.UserTypeId,
				Telephone = userResult.Telephone,	

			};
			return result;
		}
	}
}
