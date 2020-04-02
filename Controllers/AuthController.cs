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

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DataContext _dataContext;

        public AuthController(Customer dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(CustomerToRegister customerToRegister)
        {
            // lowercase email
            customerToRegister.Email.ToLower();
            // check if email already in database 
            if (await _dataContext.Customer.AnyAsync(xxx => xxx.Email == customerToRegister.Email))
                return BadRequest("This Email is already registered");

            else
            {
                // create new customer
                var newCustomer = new Customer();
                newCustomer.Email = customerToRegister.Email;
                // encrypt password
                byte[] salted = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salted);
                }
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                      password: customerToRegister.Password,
                      salt: salted,
                      prf: KeyDerivationPrf.HMACSHA1,
                      iterationCount: 10000,
                      numBytesRequested: 256 / 8));
                customerToRegister
            }


        }

    }
}