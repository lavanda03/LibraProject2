using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO.IssueDTO
{
	public class GetLogsDTO
	{ 
		public string User { get; set; }
		public string Action { get; set; }
		public string Notes { get; set; }
		public long InsertDate { get; set; }
	}
}
