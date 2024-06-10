using DataAccessLayer.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Repositories.Pos
{
	public interface IPosRepository
	{
		int AddPos(PosEntity posEntity);
		PosEntity GetPosById(int id);
        List<PosEntity> GetAllPos();
		void UpdatePos(PosEntity pos);
		void DeletePos(int Id);
		IQueryable<PosEntity> GetValidPos();
		

	}
}
