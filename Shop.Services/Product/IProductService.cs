using Shop.Entities;
using Shop.Services.Models;

namespace Shop.Services
{
	public interface IProductService
	{
		int Create(CreateProduct createProduct);
		Product Get(int id);
		void Update(Product product);
		void Delete(int id);
		List<Product> GetAll(int page, int itemsPerPage);
	}
}