using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services
{
	public class OrderService : IOrderService
	{
		public IOrderRepository orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			orderRepository = orderRepository;
		}

		public int Add(Order order)
		{
			return orderRepository.Add(order);
		}
		public Order Get(int id)
		{
			return orderRepository.Get(id);
		}
		public Order Remove(int id)
		{
			return orderRepository.Remove(id);
		}
	}
}
