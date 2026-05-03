using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;
using System.Text;

namespace Shop.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ShopDbContext dbContext;

		public ProductRepository(ShopDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public int Create(Product product)
		{
			var entityEntry = dbContext.Products.Add(product);

			dbContext.SaveChanges();

			return entityEntry.Entity.Id;
		}

		public Product Get(int id)
		{
			return dbContext.Products.SingleOrDefault(o => o.Id == id);
		}
		public void Update(Product product)
		{
			dbContext.Products.Update(product);
			dbContext.SaveChanges();
		}
		public void Delete(int id)
		{
			dbContext.Products.Where(o => o.Id == id).ExecuteDelete();
		}
		public List<Product> GetAll(int page, int itemsPerPage)
		{
			return dbContext.Products.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
		}
	}
}