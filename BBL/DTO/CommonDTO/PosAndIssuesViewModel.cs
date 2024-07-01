using BLL.DTO.IssueDTO;
using BLL.DTO.PosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO.CommonDTO
{
	public class PosAndIssuesViewModel
	{
		public GetPosDTO GetPosDTO { get; set; }
		public AddIssuesDTO AddIssuesDTO { get; set; }
	}
}
