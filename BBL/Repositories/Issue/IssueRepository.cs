using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.IssueDTO;
using DataAccessLayer;
using DAL.Entities;


namespace BLL.Repositories.Issue
{
	public class IssueRepository:IIssueRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public IssueRepository(ApplicationDbContext _dbContext)
		{
			this._dbContext = _dbContext;
		}

		public int AddIssue(AddIssuesDTO issue)
		{
			var issueEntity = new IssueEntity()
			{
				IdType = issue.IssuesType.Id,
				IdSubType = issue.IssuesType.Id,
				IdProblem = issue.IssuesType.Id,
				Priority = issue.Priority,
				IdStatus = issue.Statuses.Id,
				Description = issue.Description,
				Solotion = issue.Solotion,
				Memo = issue.Memo
				//assigned

			};

			_dbContext.Issues.Add(issueEntity);
			_dbContext.SaveChanges();
			return issueEntity.Id;
		}

		public GetIssuesDTO GetIssueById(int id)
		{

			var issueEntity = _dbContext.Issues.FirstOrDefault(u => u.Id == id);
			var result = new GetIssuesDTO()
			{
				IdPos = issueEntity.Pos.Id,
				PosName = issueEntity.Pos.Name,
				IdUserCreated = issueEntity.User.Id,
				CreationDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
				IdType = issueEntity.IssuesType.Id,
				IdStatus = issueEntity.Status.Id,
				//AssignedTo = issueEntity.User.UserType.UserType

			};
			return result;
		}

		public List<GetIssuesDTO> GetAllIssues()
		{

			_dbContext.Issues.ToList();
			return new List<GetIssuesDTO>();
			//need to change the logic
		}
		public void UpdateIssue(UpdateIssuesDTO updateIssue)
		{

			_dbContext.Entry(updateIssue).State = System.Data.Entity.EntityState.Modified;
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
