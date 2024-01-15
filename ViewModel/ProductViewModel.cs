using System;
namespace MyAspNetCoreApp.Web.ViewModel
{
	public class ProductViewModel
	{
		public ProductViewModel()
		{
		}

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Color { get; set; }
    }
}

