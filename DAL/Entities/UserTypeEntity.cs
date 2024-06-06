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
	   public UserEntity Users { get; set; }	//+
	   public List<IssueEntity> Issues { get; set; }//+



	}
}
