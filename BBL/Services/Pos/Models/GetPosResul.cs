using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.Pos.Models
{
	public class GetPosResul
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Telephone { get; set; }
		public string Address { get; set; }
        public int IssuesId { get; set; }
		public IssueData issueData { get; set; }	
	}
}
