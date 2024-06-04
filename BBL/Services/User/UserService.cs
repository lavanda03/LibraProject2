using BBL.Repositories.User;
using DataAccessLayer.Entities;

namespace BBL.Services.User
{
    public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
        {
			this.userRepository = userRepository;
        }
	    
		public int AddUser()
		{
			var id = userRepository.AddUser(new UsersEntity
			{
				Name = "test",
				IdUserType = 1
			});

			return id;
		}
	}
}
