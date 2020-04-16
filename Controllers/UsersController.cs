using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Dtos;
using ecommerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            // take user from database who has customerId  = {id}
            var user = await _dataContext.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            return Ok(user);
        }

        [HttpGet("{id}/addresses")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var user = await _dataContext.Customer.Include(i=>i.CustomerShippingAddresses).FirstOrDefaultAsync(x => x.CustomerId == id);
            return Ok(user);
        }

        [HttpGet("{id}/cart")]
        public async Task<IActionResult> GetCart(int id)
        {
            var cart = await _dataContext.Cart.Where(x=>x.CustomerId == id).ToListAsync();
            return Ok(cart);
        }

        [HttpPost("{id}/savecart")]
        public async Task<IActionResult> SaveCart(int id, List<CartToSave> CartData)
        {
            //remove cart to update new cart
            foreach(var e in _dataContext.Cart.Where(x=>x.CustomerId == id))
            {
                _dataContext.Cart.Remove(e);
            }
            await _dataContext.SaveChangesAsync();
            //var items = JsonConvert.DeserializeObject<List<Cart>>(CartData);
            foreach(var item in CartData)
            {
                var itemTosave = new Cart();
                itemTosave.CustomerId = id;
                itemTosave.productId = item.productId;
                itemTosave.productName = item.productName;
                itemTosave.productInformation = item.productInformation;
                itemTosave.productImageUrl = item.productImageUrl;
                itemTosave.quantity = item.quantity;
                itemTosave.productPrice = item.productPrice;
                await _dataContext.Cart.AddAsync(itemTosave);
            }
            await _dataContext.SaveChangesAsync();
            return Ok("save successful");
        }

    }
}