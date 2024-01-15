using System;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Models
{
	public class ProductRepository
	{
		private static List<Product> _products = new List<Product>()
	{
		new() { Id = 1, Name = "Kalem", Stock = 300 },
		new () { Id = 2, Name = "Defter", Stock = 400 },
		new () { Id = 3, Name = "Silgi", Stock = 200 },
		new() { Id = 4, Name = "Cetvel", Stock = 100 }
	};

		public List<Product> GetAll() => _products;

		public void Add(Product newProduct) => _products.Add(newProduct);

		public void Remove(int id)
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == id);

			if (hasProduct == null)
			{
				throw new Exception($"Bu id({id}) ile kayıtlı ürün bulunmamaktadır");
			}
			_products.Remove(hasProduct);
		}

		public void Update(Product updateProduct)
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

			if (hasProduct == null)
			{
				throw new Exception($"Bu id({updateProduct.Id}) ile kayıtloı ürün bulunmamaktadır");
			}

			hasProduct.Name = updateProduct.Name;
			hasProduct.Price = updateProduct.Price;
			hasProduct.Stock = updateProduct.Stock;

			var index = _products.FindIndex(x => x.Id == updateProduct.Id);
			_products[index] = hasProduct;
		}
	}
}

