﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BBL.Repositories.Issue
{
	public class IssueRepository:IIssueRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public IssueRepository(ApplicationDbContext _dbContext)
		{
			this._dbContext = _dbContext;
		}	

		public int AddIssue(IssueEntity issue)
		{
			_dbContext.Issues.Add(issue);
			_dbContext.SaveChanges();
			return issue.Id;
		}

		public IssueEntity GetIssueById(int id) 
		{
			return _dbContext.Issues.FirstOrDefault(u=>u.Id == id);	

		}

		public List<IssueEntity> GetAllIssues()
		{
			return _dbContext.Issues.ToList();	
		}

		public void UpdateIssue(IssueEntity issues)
		{

			_dbContext.Entry(issues).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public void DeleteIssue(int id) 
		{
			var issue = _dbContext.Issues.FirstOrDefault(x=>x.Id == id);	

			if (issue == null)
			{
				return;
			}

			issue.DeleteAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			_dbContext.Entry(issue).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public IQueryable<IssueEntity> GetValidIssues()
		{
			return _dbContext.Issues.Where(x => x.DeleteAt == null);
		}

	}
}
