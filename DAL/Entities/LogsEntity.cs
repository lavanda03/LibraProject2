using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class LogsEntity
	{
		public int Id { get; set; }	
		public int IdIssue { get; set; }
		public IssuesEntity Issues { get; set; }//+
		public int IdUser { get; set; }
		public UsersEntity User { get; set; }//+
		public string Action { get; set; }
		public string Notes { get; set; }
		public long InsertDate { get; set; }
	}
}
