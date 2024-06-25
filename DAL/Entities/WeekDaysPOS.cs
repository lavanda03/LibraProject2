using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class WeekDaysPos
	{
		public int Id { get; set; }
		public PosEntity PosEntity { get; set; }
		public int	IdPos { get; set; }
		public string WeekDays { get; set; }
	}
}
