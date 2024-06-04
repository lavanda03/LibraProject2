using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class CitiesEntity
	{
		public int Id { get; set; }
		public string CityName { get; set; }
		public List<PosEntity> Pos { get; set; }	//+
	}
}
