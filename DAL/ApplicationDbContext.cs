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
		public DbSet<ConnectionTypeEntity> ConnectionTypes => Set<ConnectionTypeEntity>();
		public DbSet<IssueEntity> Issues => Set<IssueEntity>();
		public DbSet<IssuesTypeEntity> IssuesType => Set<IssuesTypeEntity>();
		public DbSet<LogEntity> Logs => Set<LogEntity>();
		public DbSet<PosEntity> Pos => Set<PosEntity>();
		public DbSet<StatusEntity> Statuses => Set<StatusEntity>();
		public DbSet<UserEntity> Users => Set<UserEntity>();
		public DbSet<UserTypeEntity> UserTypes => Set<UserTypeEntity>();



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//User
			modelBuilder.Entity<UserEntity>().HasRequired(u => u.UserType).WithRequiredPrincipal(c => c.Users);


			//Pos
			modelBuilder.Entity<PosEntity>().HasRequired(u => u.Cities).WithMany(c => c.Pos).HasForeignKey(u => u.IdCity);
			modelBuilder.Entity<PosEntity>().HasRequired(u => u.ConnectionType).WithMany(c => c.Pos).HasForeignKey(u => u.IdConnType);

			//Logs
			modelBuilder.Entity<LogEntity>().HasRequired(u => u.User).WithMany(c => c.Logs).HasForeignKey(u => u.IdUser);
			modelBuilder.Entity<LogEntity>().HasRequired(u => u.Issues).WithMany(c => c.Logs).HasForeignKey(u=>u.IdIssue);


			//Issues
			modelBuilder.Entity<IssueEntity>().HasRequired(u => u.Pos).WithMany(c => c.Issues).HasForeignKey(u => u.IdPos);
			modelBuilder.Entity<IssueEntity>().HasRequired(u => u.User).WithMany(c => c.Issues).HasForeignKey(u => u.IdUserCreated);
			modelBuilder.Entity<IssueEntity>().HasRequired(u => u.UserType).WithMany(c => c.Issues).HasForeignKey(u => u.IdUserType);
			

		}


	}

}
