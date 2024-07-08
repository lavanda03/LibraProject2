using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO.IssueDTO
{
	public class GetLogssDTO
	{
		public List<GetLogsDTO> Logs { get; set; }
		public int Total { get; set; }
		public int TotalFiltered { get; set; }
	}
}
