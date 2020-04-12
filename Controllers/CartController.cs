using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private DataContext _dataContext;
        public CartController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // api/Home/Products
        /*[HttpGet("Cart/{id}")]
        public async Task<Cart> GetCart(int id)
        {
            if(_dataContext.Cart != null)
                var cart = await _dataContext.Cart.FirstOrDefault(x => x.CustomerId == id);

            return Ok(cart);
        }*/
    }
}
