using System;
using System.Collections.Generic;
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

		public void DeletePos(PosEntity pos) 
		{
			_dbContext.Pos.Remove(pos);
		    _dbContext.SaveChanges();	
		}
	}
}
