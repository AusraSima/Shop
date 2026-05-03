using Shop.Entities;

namespace Shop.Services
{
	public interface IOrderService
	{
		int Add(Order order);
		Order Get(int id);
		Order Remove(int id);
	}
}
