using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;


namespace BBL.Repositories.Pos
{
	public class PosRepository:IPosRepository
	{
		private readonly ApplicationDbContext _dbContext;	
		public PosRepository(ApplicationDbContext _dbContext) 
		{
			this._dbContext = _dbContext;	
		}
		
		public int AddPos(PosEntity posEntity)
		{
			_dbContext.Pos.Add(posEntity);
			_dbContext.SaveChanges();
			return posEntity.Id;
		}

		public PosEntity GetPosById(int id) 
		{
			return _dbContext.Pos.FirstOrDefault(u=>u.Id== id);	
		}

		public List<PosEntity> GetAllPos()
		{
			return _dbContext.Pos.ToList();

		}
		public void UpdatePos(PosEntity pos)
		{
			_dbContext.Entry(pos).State = System.Data.Entity.EntityState.Modified;
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
	}
}
