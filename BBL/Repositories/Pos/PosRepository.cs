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
using BBL.Common;
using BLL.DTO.UserDTO;


namespace BLL.Repositories.Pos
{
	public class PosRepository:IPosRepository
	{
		private readonly ApplicationDbContext _dbContext;	
		public PosRepository(ApplicationDbContext _dbContext) 
		{
			this._dbContext = _dbContext;	
		}


		public GetPossDTO QyeryPos (QueryPaginatedRequestDTO criteria)
		{
			var queryable = GetValidPos();

			if (!string.IsNullOrEmpty(criteria.SearchValue))
			{
				var search = criteria.SearchValue.ToLower();
				queryable = queryable.Where(x => x.Name.ToLower().Contains(search) ||
												 x.Telephone.ToLower().Contains(search) ||
												 x.Address.ToLower().Contains(search));
											
			}
			if (!string.IsNullOrEmpty(criteria.OrderBy))
			{
				var orderByDesc = !string.IsNullOrEmpty(criteria.Direction) && criteria.Direction.ToLower() == "desc";
				var orderBy = criteria.OrderBy.ToLower();

				switch (orderBy)
				{
					case "id":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Id)
							: queryable.OrderBy(x => x.Id);
						break;
					case "name":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Name)
							: queryable.OrderBy(x => x.Name);
						break;
					case "telephone":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Telephone)
							: queryable.OrderBy(x => x.Telephone);
						break;
					case "address":
						queryable = orderByDesc
							? queryable.OrderByDescending(x => x.Address)
							: queryable.OrderBy(x => x.Address);
						break;
				}
			}

			var filteredCount = queryable.Count();

			var views = queryable.AsEnumerable().Skip(criteria.Page.Value).Take(criteria.PageSize.Value).ToList();

			var result = new GetPossDTO
			{
				Total = GetValidPos().Count(),
				TotalFiltered = filteredCount,
				PossDTO = new List<GetPosDTO>(views.Select(x => new GetPosDTO
				{
					Id = x.Id,
					Name = x.Name,
					Telephone = x.Telephone,
					Address= x.Address
					
				}))
			};

			return result;

		}






		//public static string[] WeekDays = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

		public int AddPos(AddPOSDTO command)
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
				AfternoonOpening = command.AfternoonOpening
				
			};

			_dbContext.Pos.Add(posEntity);
			_dbContext.SaveChanges();


			foreach (var day in command.SelectedDays)
			{
				var weekEntity = new WeekDaysPos()
				{
					IdPos =posEntity.Id,
					WeekDays= day
				};

				_dbContext.WeekDaysPOS.Add(weekEntity);
				
			}
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

		
		//public List <WeekDaysPOS> GetAllWeeKDays()
		//{
		//	var weekDays = _dbContext.WeekDaysPOs.ToList();
		//	var listWeekDays = new List<WeekDaysPOS>();

		//	foreach(var day in weekDays)
		//	{
		//		listWeekDays.Add(new WeekDaysPOS
		//		{
		//			Id = day.Id,
		//			WeekDaysId = day.WeekDaysId
		//		});
		//	}
		//	return listWeekDays;
		//}
		
	}
}
