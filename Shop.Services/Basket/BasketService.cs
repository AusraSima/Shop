using Shop.Entities;
using Shop.Repositories;

namespace Shop.Services
{
	public class BasketService : IBasketService
	{
		public IBasketRepository projectBasketRepository;
		public IProductRepository projectProductRepository;
		public BasketService(IBasketRepository basketRepository, IProductRepository productRepository)
		{
			projectBasketRepository = basketRepository;
			projectProductRepository = productRepository;
		}

		public int Add(int userId, int productId, int count)
		{
			return projectBasketRepository.Add(userId, productId, count);
		}
		public Basket Get(int id)
		{
			return projectBasketRepository.Get(id);
		}
	}
}
