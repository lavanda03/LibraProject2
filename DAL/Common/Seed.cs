using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
	public class Seed
	{
		protected override void Seed(ApplicationDbContext dbContext)
		{
			dbContext.Users.AddOrUpdate(u => u.Name,
				new Entities.UserEntity
				{
					Name = "crme1",
					Email = "crme1@gmail.com",
					Password = PasswordHasher.ComputeSHA256Hash()
				}) ;
		}

	}
}
