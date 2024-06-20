using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DAL.Entities;
using BLL.DTO.PosDTO;
using System.Runtime.InteropServices;
using BBL.DTO.PosDTO;


namespace BLL.Repositories.Pos
{
	public class PosRepository:IPosRepository
	{
		private readonly ApplicationDbContext _dbContext;	
		public PosRepository(ApplicationDbContext _dbContext) 
		{
			this._dbContext = _dbContext;	
		}
		
		public int AddPos(AddPosDTO command)
		{
			var posEntity = new PosEntity()
			{
				Name = command.Name,
				Telephone = command.Telephone,
				CellPhone = command.CellPhone,
				Address = command.Address,
				City_Id = command.City_Id,
				Brand = command.Brand,
				Model = command.Model,
				ConnType_Id = command.ConnType_Id,
				MorningClosing = command.MorningClosing,
				MorningOperning = command.MorningOperning,
				AfternonClosing = command.AfternonClosing,
				AfternoonOpening = command.AfternoonOpening,
				DaysClosed = command.DaysClosed
			};

			_dbContext.Pos.Add(posEntity);
			_dbContext.SaveChanges();
			return posEntity.Id;
		}

		public GetPosDTO GetPosById(int id) 
		{

		   var posEntity = _dbContext.Pos.FirstOrDefault(u=>u.Id== id);

			var result = new GetPosDTO()
			{
				Id = posEntity.Id,
				Name = posEntity.Name,
				Telephone = posEntity.Telephone,
				Address = posEntity.Address,
			  //status

			};

			return result;
		}

		public List<GetPosDTO> GetAllPos()
		{

		    var posEntities=_dbContext.Pos.ToList();
			var result = new List<GetPosDTO>();
			
		   foreach (var i in posEntities)
		   {

				result.Add(new GetPosDTO()
				{
                    Id = i.Id,
					Name = i.Name,
					Telephone= i.Telephone,	
					Address = i.Address
					//status
				});

		   }
			return result;

		}

		public void UpdatePos(UpdatePosDTO updatePos)
		{
			_dbContext.Entry(updatePos).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public void DeletePos(int id) 
		{
			var pos = _dbContext.Pos.FirstOrDefault(x=>x.Id==id);

			if (pos == null)
			{
				return;
			}
			pos.DeleteAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

			_dbContext.Entry(pos).State = System.Data.Entity.EntityState.Modified;
			_dbContext.SaveChanges();	
		}

		public IQueryable<PosEntity> GetValidPos() 
		{
			return _dbContext.Pos.Where(x => x.DeleteAt == null);
		}


		public List<GetCitiesDTO> GetAllCitites()
		{
			var cityEntity = _dbContext.Cities.ToList();
			
			var listCities = new List<GetCitiesDTO>();	

			foreach(var city in cityEntity)
			{
				listCities.Add(new GetCitiesDTO
				{

					Id = city.Id,
					Name=city.CityName
				});
			}
			return listCities;
		}

		public List<GetConnectionsTypeDTO>GetAllConnectionType()
		{
			var conType = _dbContext.ConnectionTypes.ToList();
			var listConType = new List<GetConnectionsTypeDTO>();

			foreach (var type in  conType)
			{
				listConType.Add(new GetConnectionsTypeDTO
				{
					Id = type.Id,
					ConectionType=type.ConnectionType
				});
			}
			return listConType;
		}
	}
}
