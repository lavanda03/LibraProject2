using BBL.Services.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Services.User
{
    public interface IUserService
    {
        int AddUser(AddUserCommand command);
        List<GetUserResult> GetAllUsers();
        GetUserResult GetUserById(int id);
        void UpdateUser(UpdateUserCommand command); 
        void DeleteUser(int id);    
        GetUserResult LoginUser(string Login,string Password);
    }
}
