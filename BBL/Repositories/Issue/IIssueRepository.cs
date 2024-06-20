using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.IssueDTO;
using DAL.Entities;


namespace BLL.Repositories.Issue
{
	public interface IIssueRepository
	{
		 int AddIssue(AddIssuesDTO issue);
		GetIssuesDTO GetIssueById(int id);
		List<GetIssuesDTO> GetAllIssues();
		void UpdateIssue(UpdateIssuesDTO issue);	
		void DeleteIssue(int id);
		IQueryable<IssueEntity> GetValidIssues();
	}
}
