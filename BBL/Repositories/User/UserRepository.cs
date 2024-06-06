using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Entities;
using BBL.Repositories.User;

namespace BBL.Repositories
{
    public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext _context)
		{
		   this._context = _context;
		}

		public int AddUser(UserEntity usersEntity)
		{
			_context.Users.Add(usersEntity);
			_context.SaveChanges();	
			return usersEntity.Id;	
		}

		public List<UserEntity> GetAllUsers() 
		{
			return _context.Users.ToList();
		}

		public UserEntity GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(u => u.Id == id);
		}

		public void UpdateUser(UserEntity usersEntity) 
		{
			_context.Entry(usersEntity).State = System.Data.Entity.EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteUser(UserEntity users)
		{
			_context.Users.Remove(users);	
			_context.SaveChanges();
		}
		
		public UserEntity LoginUser(string Login,string Password)
		{
			return _context.Users.FirstOrDefault(u => u.Login.ToLower() == Login.ToLower() && u.Password.ToLower() == Password.ToLower());
		}
	}
}
