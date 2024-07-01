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
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(DataAccessLayer.ApplicationDbContext context)
		{
			string password = "1234";
			byte[] salt = PasswordHasher.GenerateSalt();
			byte[] encryptedStrig = PasswordHasher.HashPassword(password, salt);



			context.UserTypes.AddOrUpdate(u => u.Id,
				new Entities.UserTypeEntity
				{
					UserType = "admin"
				});
			context.SaveChanges();

			context.UserTypes.AddOrUpdate(u => u.Id,
				new Entities.UserTypeEntity
				{
					UserType = "tehnical group"
				});
			context.SaveChanges();


			context.Users.AddOrUpdate(u => u.Id,
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
			context.SaveChanges();

			context.Users.AddOrUpdate(u => u.Id,
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
			context.SaveChanges();


			context.Cities.AddOrUpdate(u => u.Id,
			new Entities.CityEntity
			{
				CityName = "Chisinau"
			});
			context.SaveChanges();


			context.Cities.AddOrUpdate(u => u.Id,
		    new Entities.CityEntity
		   {
			CityName = "Orhei"
		  });
			context.SaveChanges();


			context.Cities.AddOrUpdate(u => u.Id,
		   new Entities.CityEntity
		   {
			CityName = "Milano"
		   });
			context.SaveChanges();



			context.ConnectionTypes.AddOrUpdate(u => u.Id,
			   new Entities.ConnectionTypeEntity
			   {
				   ConnectionType = "Wi-Fi"
			   });
			context.SaveChanges();

			context.ConnectionTypes.AddOrUpdate(u => u.Id,
				new Entities.ConnectionTypeEntity
				{
					ConnectionType = "Remote"
				});
			context.SaveChanges();







			context.IssuesType.AddOrUpdate(u => u.Id,
				new IssuesTypeEntity
				{
					IssueLevel = 0,
					Name = "Hardware",
					InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

				});
			context.SaveChanges();


			context.IssuesType.AddOrUpdate(u => u.Id,
				new IssuesTypeEntity
				{
					IssueLevel = 1,
					Name = "Software",
					InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

				});
			context.SaveChanges();


			context.IssuesType.AddOrUpdate(u => u.Id,
				new IssuesTypeEntity
				{
					ParentIssues = 2,
					Name = "Card Reader",
					InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

				});
			context.SaveChanges();

			context.IssuesType.AddOrUpdate(u => u.Id,
			new IssuesTypeEntity
			{
				ParentIssues = 2,
				Name = "Printer",
				InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

			});
			context.SaveChanges();


			context.IssuesType.AddOrUpdate(u => u.Id,
			new IssuesTypeEntity
			{
				ParentIssues = 2,
				Name = "Power Supply",
				InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

			});
			context.SaveChanges();


			context.IssuesType.AddOrUpdate(u => u.Id,
			new IssuesTypeEntity
			{
				ParentIssues = 3,
				Name = "Application",
				InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

			});
			context.SaveChanges();


			context.IssuesType.AddOrUpdate(u => u.Id,
			new IssuesTypeEntity
			{
				ParentIssues = 3,
				Name = "Integration",
				InsertDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()

			});
			context.SaveChanges();
		}
	}
}
