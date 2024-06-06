
using BBL.Services.User.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BBL.Repositories.User
{
   public interface IUserRepository
   {
        int AddUser(UserEntity userEntity);
        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(int id);
        void UpdateUser(UserEntity userEntity);    
        void DeleteUser(UserEntity users);
        UserEntity LoginUser(string Login, string Password);
   }
}
