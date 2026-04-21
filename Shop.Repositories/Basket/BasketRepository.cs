using Shop.Entities;

namespace Shop.Repositories
{
	public class BasketRepository : IBasketRepository
	{
		private Dictionary<int, Basket> Baskets = new Dictionary<int, Basket>();

		public int Add(int userId, int productId, int count)
		{
			if (Baskets.TryGetValue(userId, out var basket))
			{
				if (basket.Products.Any(p => p.ProductId == productId))
				{
					basket.Products[productId].Count += count;
				}
				else
				{
					basket.Products.Add(new ProductInBasket()
					{
						BasketId = basket.Id,
						ProductId = productId,
						Count = count
					});
				}
			}
			else
			{
				var maxId = Baskets.Keys.Any() ? Baskets.Keys.Max() : 0;
				var newId = maxId + 1;
				basket = new Basket()
				{
					UserId = userId,
					Products = new()
							{
								new ProductInBasket()
								{
									BasketId = newId,
									ProductId = productId,
									Count = count
								}
							}
				};
				Baskets.Add(userId, basket);
			}

			return basket.Id;
		}

		public void Remove(int userId, int productId, int count)
		{
			if (Baskets.TryGetValue(productId, out var product))
			{
				if (product == null)
					Console.WriteLine("No such product in the basket");
				else
					Baskets.Remove(product.Id);
			}
		}

		public void RemoveAll(int userId, int productId)
		{
			throw new NotImplementedException();
		}

		public Basket Get(int userId)
		{
			if (Baskets.TryGetValue(userId, out var basket))
			{
				return basket;
			}
			return null;
		}
	}
}