using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BBL.Repositories.Issue
{
	public interface IIssueRepository
	{
		 int AddIssue(IssueEntity issue);
		IssueEntity GetIssueById(int id);
		List<IssueEntity> GetAllIssues();
		void UpdateIssue(IssueEntity issue);	
		void DeleteIssue(int id);
		IQueryable<IssueEntity> GetValidIssues();
	}
}
