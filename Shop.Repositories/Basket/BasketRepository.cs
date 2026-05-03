using Shop.Data;
using Shop.Entities;

namespace Shop.Repositories
{
	public class BasketRepository : IBasketRepository
	{
		private readonly ShopDbContext dbContext;
		public BasketRepository(ShopDbContext context)
		{
			this.dbContext = context;
		}

		public int Add(int userId, int productId, int count)
		{
			var basket = new Basket
			{
				UserId = userId,
				ProductInBaskets = new List<ProductInBasket>()
				{
					new ProductInBasket()
					{
						ProductId = productId,
						Count = count
					}
				}
			};

			var entityEntry = dbContext.Baskets.Add(basket);
			dbContext.SaveChanges();

			return entityEntry.Entity.Id;
		}

		public void Remove(int userId, int productId, int count)
		{
			//if (Baskets.TryGetValue(productId, out var product))
			//{
			//	if (product == null)
			//		Console.WriteLine("No such product in the basket");
			//	else
			//		Baskets.Remove(product.Id);
			//}
		}

		public void RemoveAll(int userId, int productId)
		{
			throw new NotImplementedException();
		}

		public Basket Get(int userId)
		{


			//if (Baskets.TryGetValue(userId, out var basket))
			//{
			return null;
			//}

		}

	}
}