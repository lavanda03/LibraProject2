using BBL.Repositories.User;
using BBL.Services.User.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace BBL.Services.User
{
    public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
        {
			this.userRepository = userRepository;
        }
	    
		public int AddUser(AddUserCommand command)
		{
			var userEntity = userRepository.AddUser(new UserEntity
			{
				//Name = "Julia",
				//Email = "dd.dd@.com",
				//Password = "1234",
				//Login = "crme155",
				//Telephone = "060594313",
				//IdUserType = 1
				Name = command.Name,
				Email = command.Email,
				Password = command.Password,
				Login = command.Login,
				Telephone = command.Telephone,
				IdUserType = command.IdUserType
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
					IdUserType = c.IdUserType	
					
				});
            }
			return result;
        }

		public GetUserResult GetUserById(int id) 
		{
			var userEntity = userRepository.GetUserById(id);

			var result = new GetUserResult()
			{
				Id= userEntity.Id,
				Name = userEntity.Name,
				Email = userEntity.Email,
				Login = userEntity.Login,
				Telephone = userEntity.Telephone,
				IdUserType = userEntity.IdUserType
			};
			return result;
		}

		public void UpdateUser(UpdateUserCommand command)
		{
			var userEntity = userRepository.GetUserById(command.Id);

			if(command.Name!= userEntity.Name)
			   userEntity.Name = command.Name;

			if (command.Telephone!= userEntity.Telephone)
				userEntity.Telephone = command.Telephone;

			if (command.Email != userEntity.Email)
				userEntity.Email = command.Email;

			if (command.IdUserType != userEntity.IdUserType)
				userEntity.IdUserType = command.IdUserType;


			userRepository.UpdateUser(userEntity);
		}

		public void DeleteUser(int id) 
		{
			var userEntity = userRepository.GetUserById(id);

			userRepository.DeleteUser(userEntity);
		}

		public GetUserResult LoginUser(string Login, string password)
		{
			var userResult = userRepository.LoginUser(Login, password);

			var result = new GetUserResult()
			{

				Id = userResult.Id,
				Name = userResult.Name,
				Email = userResult.Email,
				Login = userResult.Login,
				IdUserType = userResult.IdUserType,
				Telephone = userResult.Telephone,	

			};
			return result;
		}
	}
}
