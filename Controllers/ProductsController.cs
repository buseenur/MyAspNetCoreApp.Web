using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private IHelper _helper;
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IHelper helper, IMapper mapper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _helper = helper;
            _mapper = mapper;

            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "Kalem", Price = 200, Stock = 100, Color = "Red" });
            //    _context.Products.Add(new Product() { Name = "Defter", Price = 200, Stock = 100, Color = "Pink" });
            //    _context.Products.Add(new Product() { Name = "Silgi", Price = 200, Stock = 100, Color = "Green" });
            //    _context.Products.Add(new Product() { Name = "Cetvel", Price = 200, Stock = 100, Color = "Blue" });
            //    _context.SaveChanges();
            //}


        }

        public IActionResult Index()
        {
            var text = "Asp.Net Core";
            var upperText = _helper.Upper(text);
            var products = _context.Products.ToList();

            //return View(products);
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult UpdateProduct(int id)
        {
           var product = _productRepository.GetAll().FirstOrDefault(x => x.Id == id);
           var updateProduct = new Product()
            {
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price
            };
           
            return View(updateProduct);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }



        // kullanıcıdan alınan verileri yakalamak için 1. yöntem
        //[HttpPost]
        //public IActionResult SaveProduct()
        //{
        //    var name = HttpContext.Request.Form["Name"].ToString();
        //    var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
        //    var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
        //    var color = HttpContext.Request.Form["Color"].ToString();

        //    Product newProduct = new Product { Name = name, Color = color, Stock = stock, Price = price };

        //    _context.Add(newProduct);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}


        // kullanıcıdan alınan verileri yakalamak için 2. yöntem
        //[HttpPost]
        //public IActionResult AddProduct(string Name, string Color, int Stock, decimal Price)
        //{
        //    Product newProduct = new Product()
        //    {
        //        Color = Color,
        //        Name = Name,
        //        Price = Price,
        //        Stock = Stock
        //    };
        //    _context.Products.Add(newProduct);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        // kullanıcıdan alınan verileri tip güvenli alma yöntemi
        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["Status"] = "Ürün başarıyla eklendi";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId)
        {
            updateProduct.Id = productId;
            _context.Products.Add(updateProduct);
            _context.SaveChanges();

            TempData["Status"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Index");
        }
    }
}

