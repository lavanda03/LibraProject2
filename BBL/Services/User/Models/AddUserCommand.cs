using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.User.Models
{
	public class AddUserCommand
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Login { get; set; }
		public string Telephone { get; set; }
		public int IdUserType { get; set; }
	}
}
