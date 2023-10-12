using Microsoft.EntityFrameworkCore;
using ProductManagement.Interface;
using ProductManagement.Models;
using ProductManagement.Repo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProductManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly ProductContext productContext;

        public ProductService(ProductContext productContext)
        {
            this.productContext = productContext;
        }
       public List<ProductModel> GetAll()
        {
            List<ProductModel> products = productContext.Products.FromSqlRaw("GetAllProduct").ToList();
            return products;
        }

        public ProductModel AddProduct(ProductModel productModel)
        {
            return productContext.Add(productModel);
        }
    }
}
