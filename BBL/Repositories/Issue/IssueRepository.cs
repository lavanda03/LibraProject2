using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.IssueDTO;
using DataAccessLayer;
using DAL.Entities;
using BBL.DTO.PosDTO;
using BBL.Common;
using BBL.DTO.IssueDTO;


namespace BLL.Repositories.Issue
{
	public class IssueRepository:IIssueRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public IssueRepository(ApplicationDbContext _dbContext)
		{
			this._dbContext = _dbContext;
		}



		public GetIssuessDTO QueryIssue(QueryPaginatedRequestDTO criteria)
		{
			var queryable = GetValidIssues();

			if (!string.IsNullOrEmpty(criteria.SearchValue))
			{
				var search = criteria.SearchValue.ToLower();
				queryable = queryable.Where(x => x.Id.ToString().Contains(search) ||
												 x.Pos.Id.ToString().Contains(search) ||
												 x.Pos.Name.ToLower().Contains(search) ||
												 x.User.Name.ToLower().Contains(search) ||
												 x.CreationDate.ToString().Contains(search) ||
												 x.IssuesType.Name.ToLower().Contains(search) ||
												 x.Status.Status.ToLower().Contains(search) ||
												 x.UserType.UserType.ToLower().Contains(search) ||
												 x.Memo.ToLower().Contains(search));
			}

			if (!string.IsNullOrEmpty(criteria.OrderBy))
			{
				var orderByDesc = !string.IsNullOrEmpty(criteria.Direction) && criteria.Direction.ToLower() == "desc";
				var orderBy = criteria.OrderBy.Replace(" ", "").ToLower();

				switch (orderBy)
				{
					case "issue":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Id)
							: queryable.OrderBy(x => x.Id);
						break;
					case "pos.id":
						queryable = orderByDesc
						   ? queryable.OrderByDescending(x => x.Pos.Id)
						   : queryable.OrderBy(x => x.Pos.Id);
						break;
					case "pos.name":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Pos.Name)
							: queryable.OrderBy(x => x.Pos.Name);
						break;
					case "createdby":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.User.Name)
							: queryable.OrderBy(x => x.User.Name);
						break;
					case "date":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.CreationDate)
							: queryable.OrderBy(x => x.CreationDate);
						break;
					case "issuestype":
						queryable = orderByDesc
						   ? queryable.OrderByDescending(x => x.IssuesType.Name)
						   : queryable.OrderBy(x => x.IssuesType.Name);
						break;
					case "status":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Status.Status)
							: queryable.OrderBy(x => x.Status.Status);
						break;
					case "assignedto":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.UserType.UserType)
							: queryable.OrderBy(x => x.UserType.UserType);
						break;
					case "memo":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Memo)
							: queryable.OrderBy(x => x.Memo);
						break;

				}
			}

			var filteredCount = queryable.Count();

			var views = queryable.AsEnumerable().Skip(criteria.Page.Value).Take(criteria.PageSize.Value).ToList();

			var result = new GetIssuessDTO
			{

				Total = GetValidIssues().Count(),
				TotalFiltered = filteredCount,
				IssueDTO = new List<GetIssuesDTO>(views.Select(x=>new GetIssuesDTO
				{
					Id = x.Id,
					IdPos= x.IdPos,
					PosName = x.Pos.Name,
					CreatedByName = x.User.Name,
					CreationDate = x.CreationDate, //conmvert
					IssueType = x.IssuesType.Name,
					Status= x.Status.Status,
				    AssignedToName = x.User.Name,
					Memo = x.Memo,	

				}))

			};

			return result; 
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
