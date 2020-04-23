using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Dtos;
using ecommerce.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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


        [HttpPost("{id}/savehistory")]
        public async Task<IActionResult> SaveHistory(int id, OrderToSave order)
        {
            int numberOfItems = 0; double total = 0;
            foreach (var item in order.detail)
            {
                numberOfItems += item.quantity;
                total += item.productPrice * item.quantity * 8.5 / 100;
            }
            var ordertosave = new Orders();
            ordertosave.CustomerId = id;
            ordertosave.OrderName = order.name;
            ordertosave.OrderShipAddress1 = order.address1;
            ordertosave.OrderShipAddress2 = order.address2;
            ordertosave.OrderShipCity = order.city;
            ordertosave.OrderShipState = order.state;
            ordertosave.OrderShipZip5 = order.zip5;
            ordertosave.OrderShipZip4 = order.zip4;
            ordertosave.OrderDate = DateTime.Now;
            ordertosave.NumberOfItems = numberOfItems;
            ordertosave.OrderTotal = total;
            ordertosave.CardName = order.cardname;
            ordertosave.CardNumber = order.cardnumber;
            await _dataContext.Orders.AddAsync(ordertosave);
            await _dataContext.SaveChangesAsync();

            foreach(var item in order.detail)
            {
                var itemtosave = new OrderDetails();
                itemtosave.ProductId = item.productId;
                itemtosave.ProductUrl = item.productImageUrl;
                itemtosave.ProductName = item.productName;
                itemtosave.Quantity = item.quantity;
                itemtosave.SalePrice = item.productPrice;
                itemtosave.OrderId = _dataContext.Orders.Max(o => o.OrderId); // get last orderid just added 
                await _dataContext.OrderDetails.AddAsync(itemtosave);
            }
            await _dataContext.SaveChangesAsync();
            return Ok("save successful");
        }


        [HttpGet("{id}/ordershistory")]
        public async Task<IActionResult> GetOrdersHistory(int id)
        {
            var cart = await _dataContext.Cart.Where(x => x.CustomerId == id).ToListAsync();
            // get list of orders include order detail
            var history = await _dataContext.Orders.Where(x => x.CustomerId == id).Include(i => i.OrderDetails).ToListAsync();
            return Ok(history);
        }



        [HttpPost("{id}/update")]
        public async Task<IActionResult> UserUpdate(int id, UserToUpdate usertoupdate)
        {
            var user = await _dataContext.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (usertoupdate.newname != "") user.Fullname = usertoupdate.newname; 
            if (usertoupdate.newemail != "") user.Email = usertoupdate.newemail;
            if (usertoupdate.newaddress1 != "") user.Address1 = usertoupdate.newaddress1;
            if (usertoupdate.newaddress1 != "") user.Address2 = usertoupdate.newaddress2;
            if (usertoupdate.newcity != "") user.City = usertoupdate.newcity;
            if (usertoupdate.newstate != "") user.State = usertoupdate.newstate;
            if (usertoupdate.newzip4 != "") user.Zip4 = usertoupdate.newzip4;
            if (usertoupdate.newzip5 != "") user.Zip5 = usertoupdate.newzip5;

            //create new pass hash & satl for new password
            if (usertoupdate.newpassword != "")
            {
                byte[] salted = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salted);
                }
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                      password: usertoupdate.newpassword,
                      salt: salted,
                      prf: KeyDerivationPrf.HMACSHA1,
                      iterationCount: 10000,
                      numBytesRequested: 256 / 8));

                user.PasswordHashed = hashed;
                user.PasswordSalt = salted;
            }

            await _dataContext.SaveChangesAsync();
            return Ok("update successful");
        }
    }
}