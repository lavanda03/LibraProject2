using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModels.UserViewModel
{
	public class GetUserViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
		public string Telephone { get; set; }
		public int UserTypeId { get; set; }

	}
}