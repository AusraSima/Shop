using Shop.Entities;

namespace Shop.Repositories
{
	public interface IUserRepository
	{
		int Add(User user);
		User Get(int id);
		void Delete(int id);
		void ChangePassword(int id, string newPassword);
	}
}
