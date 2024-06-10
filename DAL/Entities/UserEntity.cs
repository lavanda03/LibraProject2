
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	
	public class UserEntity
	{
		[Index("Email", IsUnique = true)]
		[Index("Telephone", IsUnique = true)]
		[Index("Login", IsUnique = true)]

		public int Id { get; set; }
	    [MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Email { get; set; }
		public string Password { get; set; }
		public string Login { get; set; }
		public string Telephone { get; set; }	
		public int UserTypeId { get; set; }	
		public UserTypeEntity UserType { get; set; }//+
		public List <IssueEntity> Issues { get; set; }//+
		public List<LogEntity> Logs { get; set; }//+
		public long? DeleteAt { get; set; }
	}
}
