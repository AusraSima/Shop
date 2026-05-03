using Shop.Entities;

namespace Shop.Services
{
	public interface IUserService
	{
		int Add(User user);
		User Get(int id);
		void Delete(int id);
		void ChangePassword(int id, string newPassword);
	}
}
