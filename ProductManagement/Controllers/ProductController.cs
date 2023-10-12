using Microsoft.AspNetCore.Mvc;
using ProductManagement.Interface;
using ProductManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult ProductList()
        {
            List<ProductModel> products = productService.GetAll().ToList();
            products = products.OrderByDescending(u => u.CreationDate).ToList();    
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel productModel)
        {
            productService.AddProduct(productModel);
            return RedirectToAction("Index");
        }
    }
}
