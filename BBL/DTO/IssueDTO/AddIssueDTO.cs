﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO.IssueDTO
{
	public class AddIssuesDTO
	{
		
		public int IdPos { get; set; }	
		public int IdType { get; set; }	
		public string IssueType { get; set; }
		public int IdSubType { get; set; }  //-
	    public string SubType { get; set; }	
		public int IdProblem { get; set; }	//-
	    public string Problem { get; set; }
		public string Priority { get; set; }
		public int IdStatus { get; set; }
		public string Status { get; set; } //-
		public string Memo { get; set; }
        public int IdUserCreated { get; set; }
		public int IdUserType { get; set; }
		public string Description { get; set; }
		public long AssignedDate { get; set; }
		public long CreationDate { get; set;}
		public long ModifDate{ get; set; }
		public string Solotion { get; set; }
		

	}
}
