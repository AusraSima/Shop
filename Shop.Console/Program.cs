using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Entities;
using Shop.Repositories;
using Shop.Services;

namespace Shop.ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var host = BuildHost();

			using (var scope = host.Services.CreateScope())
			{
				var serviceProvider = scope.ServiceProvider;

				var dbContext = serviceProvider.GetRequiredService<ShopDbContext>();
				dbContext.Database.Migrate();

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
			}



			//basketService.Add(1, 1, 2);
			//basketService.Add(2, 2, 3);
			//var basket = basketService.Get(1);
			//Console.WriteLine($"userId: {basket.UserId}; productId: {basket.Products[0].ProductId}; count: {basket.Products[0].Count}");
			//basket = basketService.Get(2);
			//Console.WriteLine($"userId: {basket.UserId}; productId: {basket.Products[0].ProductId}; count: {basket.Products[0].Count}");
			//basketService.Add(1, 2, 3);
			//basketService.Add(2, 2, 5);

		}

		public static IHost BuildHost()
		{
			var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
			{
				var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

				services.AddDbContext<ShopDbContext>(options =>
				{
					options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
				});

				services.AddScoped<IProductRepository, ProductRepository>();
				services.AddScoped<IProductService, ProductService>();
				services.AddScoped<IBasketRepository, BasketRepository>();
				services.AddScoped<IBasketService, BasketService>();
			});

			return host.Build();
		}
	}
}