using Microsoft.Extensions.DependencyInjection;
using Shop.Entities;
using Shop.Repositories;
using Shop.Services;

namespace Shop.ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var collection = new ServiceCollection();

			collection.AddScoped<IProductRepository, ProductRepository>();
			collection.AddScoped<IProductService, ProductService>();
			collection.AddScoped<IBasketRepository, BasketRepository>();
			collection.AddScoped<IBasketService, BasketService>();

			var serviceProvider = collection.BuildServiceProvider();

			var productService = serviceProvider.GetRequiredService<IProductService>();
			var basketService = serviceProvider.GetRequiredService<IBasketService>();

			productService.Add(new Product()
			{
				Name = "Book",
				Price = 1.99M
			});
			productService.Add(new Product()
			{
				Name = "Pen",
				Price = 1.29M
			});

			var product = productService.Get(1);
			Console.WriteLine($"id: {product.Id}; name: {product.Name}");
			product = productService.Get(2);
			Console.WriteLine($"id: {product.Id}; name: {product.Name}");

			basketService.Add(1, 1, 2);
			basketService.Add(2, 2, 3);
			var basket = basketService.Get(1);
			Console.WriteLine($"userId: {basket.UserId}; productId: {basket.Products[0].ProductId}; count: {basket.Products[0].Count}");
			basket = basketService.Get(2);
			Console.WriteLine($"userId: {basket.UserId}; productId: {basket.Products[0].ProductId}; count: {basket.Products[0].Count}");
			basketService.Add(1, 2, 3);
			basket = basketService.Get(1);
			basketService.Add(2, 2, 5);

			Console.WriteLine("All products in the baskets:");

			for (int i = 0; i < basket.Products.Count; i++)
			{
				Console.WriteLine($"userId: {basket.UserId}; productId: {basket.Products[i].ProductId}; count: {basket.Products[i].Count}");
			}

		}
	}
}