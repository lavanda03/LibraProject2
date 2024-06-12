
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BLL.DTO.UserDTO;

namespace BLL.Repositories.User
{
    public interface IUserRepository
    {
        int AddUser(AddUserDTO addUser);
        List<GetUserDTO> GetAllUsers();
        GetUserDTO GetUserById(int id);
        void UpdateUser(UpdateUserDTO updateUser);
        void DeleteUser(int Id);
        GetUserDTO LoginUser(string Login, string Password);
        bool ExistUserByEmail(string email);
        IQueryable<UserEntity> GetValidUser();
        bool ExistLogin(string login);




	}
}
