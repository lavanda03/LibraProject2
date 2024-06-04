
using DataAccessLayer.Entities;

namespace BBL.Repositories.User
{
   public interface IUserRepository
   {
        int AddUser(UsersEntity userEntity);
   }
}
