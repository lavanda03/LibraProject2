
using BBL.Services.User.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BBL.Repositories.User
{
   public interface IUserRepository
   {
        int AddUser(UsersEntity userEntity);
        List<UsersEntity> GetAllUsers();
        UsersEntity GetUserById(int id);
        void UpdateUser(UsersEntity userEntity);    
        void DeleteUser(UsersEntity users);
        UsersEntity LoginUser(string Login, string Password);
   }
}
