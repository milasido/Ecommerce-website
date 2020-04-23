using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // api/Home/Products
        [HttpGet("Products")]
        public ActionResult GetAllProduct()
        {
            return Ok(_dataContext.Products.ToList());
        }

        // api/Home/Product/id =>get one product for add cart
        [HttpGet("Product/{id}")]
        public async Task<ActionResult> GetOneProduct(int id)
        {
            var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            return Ok(product);
        }

        //api/home/products/{id}
        [HttpGet("Products/{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var detail = await _dataContext.ProductDetails.FirstOrDefaultAsync(x => x.ProductId == id);
            return Ok(detail);
        }
    }
}