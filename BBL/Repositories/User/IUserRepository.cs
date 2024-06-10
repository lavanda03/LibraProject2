﻿
using BBL.Services.User.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BBL.Repositories.User
{
    public interface IUserRepository
    {
        int AddUser(UserEntity userEntity);
        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(int id);
        void UpdateUser(UserEntity userEntity);
        void DeleteUser(int Id);
        UserEntity LoginUser(string Login, string Password);
        bool ExistUserByEmail(string email);
        IQueryable<UserEntity> GetValidUser();




    }
}
