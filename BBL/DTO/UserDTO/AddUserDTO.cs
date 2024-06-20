using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.UserDTO
{
	public class AddUserDTO
	{
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(50, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 50 characters.")]
		public string Name { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
		public string Login { get; set; }
		public string Telephone { get; set; }
		public int UserTypeId { get; set; }
	}
}
