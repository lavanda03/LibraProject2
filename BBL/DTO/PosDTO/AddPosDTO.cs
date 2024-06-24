
namespace BLL.DTO.PosDTO
{
	public class AddPosDTO
	{
		public string Name { get; set; }
		public string Telephone { get; set; }
		public string CellPhone { get; set; }
		public string Address { get; set; }
		public int City_Id { get; set; }
		public string CityName { get; set;}
		public string Model { get; set; }
		public string Brand { get; set; }
		public int ConnType_Id { get; set; }
		public string ConnectionType { get; set; }
		public string MorningOperning { get; set; }
		public string MorningClosing { get; set; }
		public string AfternoonOpening { get; set; }
		public string AfternonClosing { get; set; }
		public string DaysClosed { get; set; }
		public long InsertDate { get; set; }

	}
}
