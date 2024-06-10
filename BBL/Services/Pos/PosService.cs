using BBL.Repositories.Pos;
using BBL.Services.Pos.Models;
using BBL.Services.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.Pos
{
	public class PosService:IPosInterface
	{
		private readonly IPosRepository posRepository;	
		public PosService(IPosRepository posRepository) 
		{ 
	         this.posRepository= posRepository;	
		}

		private bool IsValidPhone(string phoneNumber)
		{
			foreach (char digit in phoneNumber)
			{
				if (!char.IsDigit(digit) && !char.IsSymbol('+'))
				{
					return false;
				}
			}

			return true;
		}
		public int AddPos(AddPosCommand command)
		{
			var result = posRepository.AddPos(new DataAccessLayer.Entities.PosEntity
			{
				Name = command.Name,
				Telephone = command.Telephone,
				CellPhone = command.CellPhone,
				Address= command.Address,	
				City_Id= command.City_Id,	
				Brand= command.Brand,	
				Model= command.Model,
				ConnType_Id = command.ConnType_Id,
				MorningClosing= command.MorningClosing,
				MorningOperning=command.MorningOperning,
				AfternonClosing= command.AfternonClosing,
				AfternoonOpening= command.AfternoonOpening,
				DaysClosed=command.DaysClosed

			}) ;
			return result;

		}

		public List<GetPosResul> GetAllPos()
		{
			var posEntity = posRepository.GetAllPos();

			 List<GetPosResul> result = new List<GetPosResul>();

			foreach (var i in posEntity)
			{
				result.Add(new GetPosResul
				{
					Id = i.Id,
					Name = i.Name,
					Telephone = i.Telephone,
					Address = i.Address,
					issueData = new IssueData()
					
				});


			}

			return result;
		}

		public void UpdatePos(UpdatePosCommnad commnad)
		{
			var posEntity = posRepository.GetPosById(commnad.Id);

			if (posEntity.Name != commnad.Name)
			{
				posEntity.Name = commnad.Name;
			}
			if (posEntity.Telephone != commnad.Telephone)
			{
				posEntity.Telephone = commnad.Telephone;
			}
			if (posEntity.CellPhone != commnad.CellPhone)
			{
				posEntity.CellPhone = commnad.CellPhone;
			}
			if (posEntity.Address!= commnad.Address)
			{
				posEntity.Address = commnad.Address;
			}
			if (posEntity.City_Id != commnad.City_Id)
			{
				posEntity.City_Id = commnad.City_Id	;
			}
			if (posEntity.Brand != commnad.Brand)
			{
				posEntity.Brand = commnad.Brand;
			}
			if (posEntity.Model != commnad.Model)
			{
				posEntity.Model = commnad.Model;
			}
			if (posEntity.ConnType_Id != commnad.ConnType_Id)
			{
				posEntity.ConnType_Id = commnad.ConnType_Id;
			}
			if (posEntity.MorningOperning != commnad.MorningOperning)
			{
				posEntity.MorningOperning = commnad.MorningOperning;
			}
			if (posEntity.MorningClosing != commnad.MorningClosing)
			{
				posEntity.MorningClosing = commnad.MorningClosing;
			}
			if (posEntity.AfternonClosing != commnad.AfternonClosing)
			{
				posEntity.AfternonClosing = commnad.AfternonClosing;
			}
			if (posEntity.AfternoonOpening!= commnad.AfternoonOpening)
			{
				posEntity.AfternoonOpening = commnad.AfternoonOpening;
			}
			if (posEntity.DaysClosed != commnad.DaysClosed)
			{
				posEntity.DaysClosed = commnad.DaysClosed;
			}

			posRepository.UpdatePos(posEntity);
		}

		public void DeletePos(int id)
		{
			var posEntity = posRepository.GetPosById(id);

			posRepository.DeletePos(posEntity.Id);

		}
			
	}


}



