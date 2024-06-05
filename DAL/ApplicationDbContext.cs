using System;
using System.Data.Common;
using System.Data.Entity;
using DataAccessLayer.Entities;


namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
	{


        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
        }

        public ApplicationDbContext() : base("name=MyDbContext")
		{

		}

        public DbSet<CitiesEntity> Cities => Set<CitiesEntity>();
		public DbSet<ConnectionTypesEntity> ConnectionTypes => Set<ConnectionTypesEntity>();
		public DbSet<IssuesEntity> Issues => Set<IssuesEntity>();
		public DbSet<IssuesTypesEntity> IssuesType => Set<IssuesTypesEntity>();
		public DbSet<LogsEntity> Logs => Set<LogsEntity>();
		public DbSet<PosEntity> Pos => Set<PosEntity>();
		public DbSet<StatusesEntity> Statuses => Set<StatusesEntity>();
		public DbSet<UsersEntity> Users => Set<UsersEntity>();
		public DbSet<UserTypeEntity> UserTypes => Set<UserTypeEntity>();



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//User
			modelBuilder.Entity<UsersEntity>().HasRequired(u => u.UserType).WithRequiredPrincipal(c => c.Users);//sau one to one

			//Pos
			modelBuilder.Entity<PosEntity>().HasRequired(u => u.Cities).WithMany(c => c.Pos);
			modelBuilder.Entity<PosEntity>().HasRequired(u => u.ConnectionType).WithMany(c => c.Pos);

			//Logs
			modelBuilder.Entity<LogsEntity>().HasRequired(u => u.User).WithMany(c => c.Logs);
			modelBuilder.Entity<LogsEntity>().HasRequired(u => u.Issues).WithMany(c => c.Logs);


			//Issues
			modelBuilder.Entity<IssuesEntity>().HasRequired(u => u.Pos).WithMany(c => c.Issues);
			modelBuilder.Entity<IssuesEntity>().HasRequired(u => u.User).WithMany(c => c.Issues);
			modelBuilder.Entity<IssuesEntity>().HasRequired(u => u.UserType).WithMany(c => c.Issues);

		}


	}

}
