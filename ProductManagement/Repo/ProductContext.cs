using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement.Repo
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }

        /// <summary>
        /// This method is executing storeProcedure for adding and updating product.
        /// </summary>
        /// <param name="productModel">Provide product model for enter the data which we provide in store procedure parameter</param>
        /// <returns>Return Product Model which we enter</returns>
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
    /// <summary>
    /// This method is executing delete product store procedure.
    /// </summary>
    /// <param name="productId">Provide productId for store procedure parameter</param>
    /// <returns>Return string "ProductDeleted"</returns>
        public string Delete(int productId)
        {
            Database.ExecuteSqlRaw("exec DeleteProduct @productId",
                new SqlParameter("productId", productId));
            return "ProductDeleted";
        }
    }
}
