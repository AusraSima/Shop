using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services
{
	public class UserService : IUserService
	{
		public IUserRepository userRepository;
		public UserService(IUserRepository userRepository)
		{
			userRepository = userRepository;
		}
		public int Add(User user)
		{
			return userRepository.Add(user);
		}
		public User Get(int id)
		{
			return userRepository.Get(id);
		}
		public void Delete(int id)
		{
			userRepository.Delete(id);

		}
		public void ChangePassword(int id, string newPassword)
		{
			userRepository.ChangePassword(id, newPassword);
		}
	}
}
