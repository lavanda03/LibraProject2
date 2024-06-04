using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class UserTypeEntity
	{
       public int Id { get; set; }	
	   public string UserType { get; set; }
	   public List<UsersEntity> Users { get; set; }	//+
	   public List<IssuesEntity> Issues { get; set; }//+



	}
}
