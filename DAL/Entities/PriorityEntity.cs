﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class PriorityEntity
	{ 
		public int Id { get; set; }	
		public string PriorityName { get; set; }

		public List<IssueEntity> Issues { get; set; }
	}
}
