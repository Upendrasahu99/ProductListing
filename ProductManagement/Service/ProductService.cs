using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Interface;
using ProductManagement.Models;
using ProductManagement.Repo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProductManagement.Service
{
    /// <summary>
    /// This class is implemented IProductService Interface.
    /// we provide ProductService class dependency for excessing store procedure and product entity.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ProductContext productContext;

        public ProductService(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        /// <summary>
        /// This method is executed GetAllProduct Sql store procedure using productContext and return all product list.
        /// </summary>
        /// <returns></returns>
       public List<ProductModel> GetAll()
        {
            List<ProductModel> products = productContext.Products.FromSqlRaw("GetAllProduct").ToList();
            return products;
        }

        /// <summary>
        /// This method is Adding Product
        /// </summary>
        /// <param name="productModel">Passing model for enter the data for particular type</param>
        /// <returns>Return product Model</returns>
        public ProductModel AddProduct(ProductModel productModel)
        {
            return productContext.Add(productModel);
        }

        /// <summary>
        /// This method is deleting product from list.
        /// </summary>
        /// <param name="productId">Providing ProductId for deleting particular product</param>
        /// <returns>Return string "ProductDeleted"</returns>
        public string DeleteProduct(int productId)
        {
            return productContext.Delete(productId);
        }

        
    }
}
