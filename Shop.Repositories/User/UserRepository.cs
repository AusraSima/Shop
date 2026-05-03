using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;

namespace Shop.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ShopDbContext dbContext;

		public UserRepository(ShopDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public int Add(User user)
		{
			var entityEntry = dbContext.Users.Add(user);
			dbContext.SaveChanges();
			return entityEntry.Entity.Id;
		}

		public User Get(int id)
		{
			return dbContext.Users.SingleOrDefault(o => o.Id == id);
		}

		public void Delete(int id)
		{
			dbContext.Users.Where(o => o.Id == id).ExecuteDelete();
			dbContext.SaveChanges();
			Console.WriteLine($"User with id {id} has been deleted.");
		}

		public void ChangePassword(int id, string newPassword)
		{
			dbContext.Users.Where(o => o.Id == id).ExecuteUpdate(o => o.SetProperty(p => p.Password, newPassword));
			dbContext.SaveChanges();
			Console.WriteLine("Password changed");
		}
	}
}
