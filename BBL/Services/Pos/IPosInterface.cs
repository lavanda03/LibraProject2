using BBL.Repositories.Pos;
using BBL.Services.Pos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.Pos
{
	public interface IPosInterface
	{
		int AddPos(AddPosCommand command);
		List<GetPosResul> GetAllPos();
	    void UpdatePos(UpdatePosCommnad commnad);
		void DeletePos(int id);
		

	}
}
