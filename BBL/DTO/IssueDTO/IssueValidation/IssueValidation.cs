using BLL.DTO.PosDTO;
using BLL.Repositories.Issue;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.IssueDTO.IssueValidation
{
    public class IssueValidation : AbstractValidator<AddIssuesDTO>
	{
		private readonly IIssueRepository issueRepository;

		public IssueValidation(IIssueRepository issueRepository) 
		{
			this.issueRepository = issueRepository;


			RuleFor(p => p.Description).NotEmpty().WithMessage("Problem Description is required");
			RuleFor(p => p.Solution).NotEmpty().WithMessage("Solution  is required");
			RuleFor(p => p.Memo).NotEmpty().WithMessage("Memo is required");

			RuleFor(p => p.IssueType).NotEmpty().WithMessage("IssueTypeDescription is required");
			RuleFor(p => p.SubType).NotEmpty().WithMessage("SubType  is required");
			RuleFor(p => p.Problem).NotEmpty().WithMessage("Problem is required");
			RuleFor(p => p.Status).NotEmpty().WithMessage("Status  is required");
			RuleFor(p => p.Priority).NotEmpty().WithMessage("Priorityis required");




		}


	}
}
