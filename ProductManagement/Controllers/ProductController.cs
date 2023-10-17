using Microsoft.AspNetCore.Mvc;
using ProductManagement.Interface;
using ProductManagement.Models;
using System;
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

        /// <summary>
        /// This action method is generate the view and fetched the data fo all product.
        /// </summary>
        /// <param name="keyword">For Searching particular string and date in all column.</param>
        /// <returns>Return ProductList View</returns>
        public IActionResult ProductList(string keyword)
        {
            try
            {
                List<ProductModel> products = productService.GetAll().ToList();
                products = products.OrderByDescending(u => u.CreationDate).ToList();
                if (keyword != null)
                {
                    products = products.Where(u => u.ProductName.Contains(keyword) || u.Description.Contains(keyword) || u.Category.Contains(keyword) || u.Status.Contains(keyword) || u.Status.Contains(keyword)).ToList();
                }
                return View(products);
            }
            catch(Exception e)
            {
                TempData["FetchErrorMsg"] = "Some error come when fetching the data " + e.Message;
                return View();
            }
        }

        /// <summary>
        /// This Method Generate the view for Create and Update. In Update data also coming in input block
        /// </summary>
        /// <param name="code">For particular product we want to update.</param>
        /// <returns>Return Update Product view if try block executed otherwise it will return to Product List Action</returns>
        [HttpGet]
        public IActionResult AddUpdate(int code)
        {
            try
            {
                List<ProductModel> products = productService.GetAll().ToList();
                ProductModel product = products.SingleOrDefault(u => u.Code == code);

                if (product != null)
                {
                    return View(product);
                }
                else
                {
                    ProductModel productModel = new ProductModel();
                    return View(productModel);
                }
            }
            catch(Exception e)
            {
                TempData["Msg"] = "Some error come." + e.Message;
                return RedirectToAction("ProductList");
            }
        }

        /// <summary>
        /// This Method is use for Add the product data
        /// </summary>
        /// <param name="productModel">Passing model for enter the data for particular type</param>
        /// <returns>It will return to Product List Action if error occurs it will return to action AddUpdate.</returns>
        [HttpPost]
        public IActionResult AddUpdate(ProductModel productModel)
        {
            try
            {
                productService.AddProduct(productModel);
                return RedirectToAction("ProductList");
            }
            catch(Exception e)
            {
                TempData["Msg"] = "Product added Fail." + e.Message;
                return RedirectToAction("AddUpdate");
            }
        }

        /// <summary>
        /// This Method is use for deleting product data
        /// </summary>
        /// <param name="id">Passing product id for delete particular product</param>
        /// <returns>It will return to action Product List if error occurs it will return message in Product List View.</returns>
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            try
            {
                productService.DeleteProduct(id);
                return RedirectToAction("ProductList");
            }
            catch(Exception e)
            {
                TempData["MsgDelete"] = "Product added Fail." + e.Message;
                return RedirectToAction("ProductList");
            }
        }
    }
}
