using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using Ecommerce_website.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public HomeController(IProductRepository repo)
        {
            _repo = repo;
        }

        // api/Home/Products
        [HttpGet("Products")]
        public ActionResult GetAllProduct()
        {
            var allProducts = _repo.GetAllProduct();
            return Ok(allProducts);
        }

        // api/Home/Product/id =>get one product for add cart
        [HttpGet("Product/{id}")]
        public async Task<ActionResult> GetOneProduct(int id)
        {
            var product = await _repo.GetOneProduct(id);
            return Ok(product);
        }

        //api/home/products/{id}
        [HttpGet("Products/{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var detail = await _repo.GetProductDetail(id);
            return Ok(detail);
        }
    }
}