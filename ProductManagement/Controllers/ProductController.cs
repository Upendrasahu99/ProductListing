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

        public IActionResult ProductList(string keyword)
        {
            List<ProductModel> products = productService.GetAll().ToList();
            products = products.OrderByDescending(u => u.CreationDate).ToList();    
            if(keyword != null)
            {
                products = products.Where(u => u.ProductName.Contains(keyword) || u.Description.Contains(keyword) || u.Category.Contains(keyword) || u.Status.Contains(keyword) || u.Status.Contains(keyword)).ToList();
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult AddUpdate(int code)
        {
            List<ProductModel> products = productService.GetAll().ToList();
            ProductModel product = products.SingleOrDefault(u => u.Code == code);

            if(product != null)
            {
                return View(product);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddUpdate(ProductModel productModel)
        {
            productService.AddProduct(productModel);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            
            productService.DeleteProduct(id);
            return RedirectToAction("ProductList");
        }
    }
}
