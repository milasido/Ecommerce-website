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
        public ActionResult Get()
        {
            return Ok(_dataContext.Products.ToList());
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