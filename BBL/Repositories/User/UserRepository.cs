using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DAL.Entities;
using BLL.Repositories.User;
using System.Text.RegularExpressions;
using System;
using BLL.DTO.UserDTO;
using DAL.Common;
using System.Data.Entity;


namespace BLL.Repositories
{
    public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext _context)
		{
		   this._context = _context;
		}

		public int AddUser(AddUserDTO command)
		{
			byte[] salt = PasswordHasher.GenerateSalt();
			byte[] hash = PasswordHasher.HashPassword(command.Password, salt);

			var userEntity = new UserEntity()
			{
				Name = command.Name,
				Email= command.Email,
				Salt = salt,
				PasswordHash = hash,
				Login=command.Login,
				Telephone=command.Telephone,	
				UserTypeId = command.UserTypeId,	
			};
			_context.Users.Add(userEntity);
			_context.SaveChanges();	
			return userEntity.Id;	
		}

		public GetUsersDTO GetAllUsers() 
		{
			var result = new GetUsersDTO
			{
				UserDTO = new List<GetUserDTO>()
			};
			var usersEntity=_context.Users.ToList();

			foreach(var x in usersEntity)
			{
				result.UserDTO.Add(new GetUserDTO
				{
					Id = x.Id,
					Name = x.Name,
					Email = x.Email,
					Login = x.Login,
					Telephone = x.Telephone,
					UserTypeId = x.UserTypeId,
					
				}); 
			}

			return result;
		}

		public GetUserDTO GetUserById(int id)
		{
			var userEntity=_context.Users.FirstOrDefault(u => u.Id == id);
			//verificare null?
			var result = new GetUserDTO()
			{
				Name = userEntity.Name,
				Email = userEntity.Email,
				Login = userEntity.Login,
				Telephone = userEntity.Telephone,
				UserTypeId= userEntity.UserTypeId,
				UserType = userEntity.UserType.UserType
			};

			return result;
		}

		public void UpdateUser(UpdateUserDTO updateUser) 
		{
			_context.Entry(updateUser).State = System.Data.Entity.EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteUser(int id)
		{
			var user = _context.Users.FirstOrDefault(x => x.Id == id);

			if (user == null) 
			{
				return;
			}

			user.DeleteAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

			_context.Entry(user).State = System.Data.Entity.EntityState.Modified;
			_context.SaveChanges();
		}
		public IQueryable<UserEntity> GetValidUser()
		{
			return _context.Users.Where(x => x.DeleteAt == null);
		}

		public GetUserDTO LoginUser(string Login,string Password)
		{
			//var userEntity = _context.Users.FirstOrDefault(u => u.Login == Login);

			var userEntity = _context.Users.Include(u => u.UserType).FirstOrDefault(u => u.Login == Login);

			if (userEntity != null)
			{
				if (PasswordHasher.VerifyPassword(Password, userEntity.Salt, userEntity.PasswordHash))
				{

					return new GetUserDTO
					{
						Id = userEntity.Id,
						Name = userEntity.Name,
						Email = userEntity.Email,
						Login = userEntity.Login,
						UserTypeId = userEntity.UserTypeId,
						Telephone = userEntity.Telephone,
						UserType = userEntity.UserType.UserType
					};
				}

			}
			return null;
		}
		public bool ExistUserByEmail(string email)
		{
			return _context.Users.Any(u => u.Email.ToLower() == email.ToLower());
			
		}
		public bool ExistLogin(string login)
		{
			return !_context.Users.Any(x => x.Login == login);
		}
	}
}
