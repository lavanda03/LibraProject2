using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class PosEntity
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public string Telephone { get; set; }
		public string CellPhone { get; set; }
		public string Address { get; set; }
		public int IdCity { get; set; }
		public CitiesEntity Cities { get; set; }	//+
		public string Model { get; set; }
		public string Brand { get; set;}
		public int IdConnType { get; set; }	
	    public ConnectionTypesEntity ConnectionType {get;set;}//+
		public string MorningOperning {  get; set; }	
		public string MorningClosing { get; set; }
		public string AfternoonOpening { get; set; }
		public string AfternonClosing { get; set; }
		public string DaysClosed { get; set; }
		public long InsertDate { get; set; }
		public List<IssuesEntity> Issues { get; set; }//+


	}
}
