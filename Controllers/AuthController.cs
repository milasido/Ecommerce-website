using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Dtos;
using ecommerce.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;


namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DataContext _dataContext;
        private ApplicationSettings _appsetting;
        private Functions _func;

        public AuthController(DataContext dataContext, IOptions<ApplicationSettings> appsetting, Functions func)
        {
            _dataContext = dataContext;
            _appsetting = appsetting.Value;
            _func = func;
        }

        // api/Auth/register
        [HttpPost("register")]
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
                // encrypt password
                byte[] salted; string hashed;
                _func.HashPassword(customerToRegister.Password, out salted, out hashed);
                // store password hashed for new customer
                newCustomer.PasswordHashed = hashed;
                newCustomer.PasswordSalt = salted;
                newCustomer.DateCreated = DateTime.Now;
                newCustomer.Email = customerToRegister.Email;
                // add new customer to database
                await _dataContext.Customer.AddAsync(newCustomer);
                return StatusCode(201);
            }
        }
            
        // api/Auth/login        
        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomerToLogin customerToLogin)
        {
            // lowercase email
            customerToLogin.Email.ToLower();
            // find email in database
            if (await _dataContext.Customer.AnyAsync(xxx => xxx.Email == customerToLogin.Email))
            {
                // take customer from database
                var user = await _dataContext.Customer.FirstOrDefaultAsync(xxx => xxx.Email == customerToLogin.Email);
                // hash password from login
                byte[] salted; string hashed;
                _func.HashPassword(customerToLogin.Password, out salted, out hashed);
                // compare 2 hashed passwords
                if (hashed != user.PasswordHashed)
                    return BadRequest(new { message = "Wrong Password!" });
                else
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("CustomerId", user.CustomerId.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsetting.JWT_Secret)),
                            SecurityAlgorithms.HmacSha256Signature)
                    };
                    // store last login for user is now.
                    user.LastLogin = DateTime.Now;
                    // store user into database
                    await _dataContext.Customer.AddAsync(user);
                    await _dataContext.SaveChangesAsync();
                    

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var sercurityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(sercurityToken);
                    return Ok(new { token });
                }
            }
            else return BadRequest(new { message = "This email is not registered" });
        }
        
        

    }
}