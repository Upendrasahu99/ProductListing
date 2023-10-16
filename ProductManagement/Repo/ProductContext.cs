using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement.Repo
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }

        //Add Product in Product table
        public ProductModel Add(ProductModel productModel)
        {
            
            Database.ExecuteSqlRaw("exec AddProduct @code, @productName, @description, @expiryDate, @category, @productImage, @status",
                    new SqlParameter("code", productModel.Code),
                    new SqlParameter("productName", productModel.ProductName),
                    new SqlParameter("description", productModel.Description),
                    new SqlParameter("expiryDate", productModel.ExpiryDate),
                    new SqlParameter("category", productModel.Category),
                    new SqlParameter("productImage", productModel.ProductImage),
                    new SqlParameter("status", productModel.Status)
                    );

            return productModel;
        }
    
        public string Delete(int productId)
        {
            Database.ExecuteSqlRaw("exec DeleteProduct @productId",
                new SqlParameter("productId", productId));
            return "ProductDeleted";
        }
    }
}
