using Shop.Entities;

namespace Shop.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private Dictionary<int, Basket> Baskets = new Dictionary<int, Basket>();

        public int Add(int userId, int productId, int count)
        {
            var maxId = Baskets.Keys.Any() ? Baskets.Keys.Max() : 0;
            var newId = maxId + 1;
            var basket = new Basket()
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

            basket.Id = newId;

            Baskets.Add(userId, basket);

            return basket.Id;
        }

        public void Remove(int userId, int productId, int count)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(int userId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}