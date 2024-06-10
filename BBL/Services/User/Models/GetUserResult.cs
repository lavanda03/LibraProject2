﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.User.Models
{
	public class GetUserResult
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
		public string Telephone { get; set; }
		public int UserTypeId { get; set; }
	}
}
