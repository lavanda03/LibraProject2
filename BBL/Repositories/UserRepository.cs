using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BBL.Repositories
{
	public class UserRepository
	{

		private readonly ApplicationDbContext _context;

		public UserRepository()
		{
			_context = new ApplicationDbContext();	
		}

		public int AddUser(UsersEntity usersEntity)
		{
			_context.Users.Add(usersEntity);
			_context.SaveChanges();	
			return usersEntity.Id;	
		}

		public List<UsersEntity> GetAllUsers() 
		{
			return _context.Users.ToList();
		}

		public UsersEntity GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(u => u.Id == id);
		}

		public void UpdateUser(UsersEntity usersEntity) 
		{
			_context.Entry(usersEntity).State = System.Data.Entity.EntityState.Modified;
			_context.SaveChanges();
		}

		public void DeleteUser(UsersEntity users)
		{
			_context.Users.Remove(users);	
			_context.SaveChanges();
		}
		
		public UsersEntity LoginUser(string Login,string Password)
		{
			return _context.Users.FirstOrDefault(u => u.Login.ToLower() == Login.ToLower() && u.Password.ToLower() == Password.ToLower());
		}
	}
}
