using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class WeekDaysPOS
	{ 
		public int Id { get; set; }
		public PosEntity PosEntity { get; set; }
		public int PosId { get; set; }
		public WeekDays WeekDays { get; set; }	
		public int WeekDaysId { get; set; }	
	}
}
