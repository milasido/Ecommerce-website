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

        public AuthController(DataContext dataContext, IOptions<ApplicationSettings> appsetting)
        {
            _dataContext = dataContext;
            _appsetting = appsetting.Value;
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
                // store password hashed for new customer
                newCustomer.PasswordHashed = hashed;
                newCustomer.PasswordSalt = salted;
                newCustomer.DateCreated = DateTime.Now;
                // add new customer to database
                await _dataContext.Customer.AddAsync(newCustomer);
                await _dataContext.SaveChangesAsync();
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
                byte[] salted = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salted);
                }
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                      password: customerToLogin.Password,
                      salt: salted,
                      prf: KeyDerivationPrf.HMACSHA1,
                      iterationCount: 10000,
                      numBytesRequested: 256 / 8));
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
                    //user.LastLogin = DateTime.Now;
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