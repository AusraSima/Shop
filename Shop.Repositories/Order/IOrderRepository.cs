using Shop.Entities;

namespace Shop.Repositories
{
	public interface IOrderRepository
	{
		int Add(Order order);
		Order Get(int id);
		Order Remove(int id);
	}
}
