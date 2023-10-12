using ProductManagement.Models;
using System.Collections.Generic;

namespace ProductManagement.Interface

{
    public interface IProductService
    {
        public List<ProductModel> GetAll();
        public ProductModel AddProduct(ProductModel productModel);
    }
}
