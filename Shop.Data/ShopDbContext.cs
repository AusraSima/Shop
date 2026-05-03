using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.Data
{
	public class ShopDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }

		public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>(o =>
				{
					o.HasKey(e => e.Id);
					o.Property(e => e.Name).IsRequired();
					o.Property(e => e.Price).IsRequired();
				});
			modelBuilder.Entity<ProductInBasket>(o =>
			{
				o.HasKey(e => e.Id);
				o.HasOne(e => e.Basket)
					.WithMany(b => b.ProductInBaskets)
					.HasForeignKey(e => e.BasketId);
				o.HasOne(e => e.Product)
					.WithMany(p => p.ProductInBaskets)
					.HasForeignKey(e => e.ProductId);
			});
		}
	}
}
