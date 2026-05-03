using Shop.Entities;

namespace Shop.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private Dictionary<int, Order> Orders { get; set; } = new Dictionary<int, Order>();
		public int Add(Order order)
		{
			var maxId = Orders.Keys.Any() ? Orders.Keys.Max() : 0;
			order.Id = maxId + 1;
			Orders.Add(order.Id, order);
			return order.Id;
		}
		public Order Get(int id)
		{
			if (Orders.TryGetValue(id, out var order))
				return order;
			return null;
		}
		public Order Remove(int id)
		{
			if (Orders.TryGetValue(id, out var order))
			{
				Orders.Remove(id);
				return order;
			}
			return null;
		}
	}
}
