﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class IssuesTypeEntity
	{
		public int Id { get; set; }	
		public int IssueLevel { get; set; }
		public string ParentIssues {  get; set; }	
		public string Name { get; set; }
		public long InsertDate { get; set; }
	}
}