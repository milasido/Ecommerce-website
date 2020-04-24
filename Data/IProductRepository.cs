using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_website.Data
{
    public interface IProductRepository
    {
        public List<Products>  GetAllProduct();
         public Task<Products> GetOneProduct(int id);
         public Task<ProductDetails>GetProductDetail(int id);
    }
}