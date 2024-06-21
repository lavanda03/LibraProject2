using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class WeekDays
	{
		public int Id { get; set; }
		public string WeekName { get; set; }
		public List<WeekDaysPOS> WeekDaysPos { get; set; }	
	}
}
