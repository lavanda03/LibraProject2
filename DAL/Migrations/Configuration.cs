namespace DAL.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
	using System.Data.Entity.ModelConfiguration.Configuration;
	using System.Linq;
	using System.Runtime.Remoting.Contexts;
	using DAL.Common;
	using DAL.Entities;

	internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = false;
		}

		protected override void Seed(DataAccessLayer.ApplicationDbContext context)
		{
			string password = "1234";
			byte[] salt = PasswordHasher.GenerateSalt();
			byte[] encryptedStrig = PasswordHasher.HashPassword(password, salt);



			context.UserTypes.AddOrUpdate(u => u.UserType,
				new Entities.UserTypeEntity
				{
					UserType = "admin"
				});
			context.SaveChanges();

			context.UserTypes.AddOrUpdate(u => u.UserType,
				new Entities.UserTypeEntity
				{
					UserType = "tehnical group"
				});
			context.SaveChanges();


			context.Users.AddOrUpdate(u => u.Name,
				new Entities.UserEntity
				{
					Name = "crme1",
					Email = "crme1@gmail.com",
					PasswordHash = encryptedStrig,
					Login = "crme1",
					Telephone = "55424525",
					UserTypeId = 1,
					Salt = salt

				});

			context.Users.AddOrUpdate(u => u.Name,
				new Entities.UserEntity
				{
					Name = "crme2",
					Email = "crme2@gmail.com",
					PasswordHash = encryptedStrig,
					Login = "crme2",
					Telephone = "5542425",
					UserTypeId = 2,
					Salt = salt
				});


			var cities = new List<CityEntity>()
			{
				new CityEntity {CityName = "Chisinau" },
				new CityEntity {CityName = "Orhei"},
				new CityEntity {CityName = "Milano"}

			};

			foreach (var city in cities)
			{
				context.Cities.AddOrUpdate(u => u.Id, city);
			}
			context.SaveChanges();


			context.ConnectionTypes.AddOrUpdate(u => u.ConnectionType,
				new Entities.ConnectionTypeEntity
				{
					ConnectionType = "Wi-Fi"
				});
			context.SaveChanges();

			context.ConnectionTypes.AddOrUpdate(u => u.ConnectionType,
				new Entities.ConnectionTypeEntity
				{
					ConnectionType = "Remote"
				});
			context.SaveChanges();

		}
	}
}
