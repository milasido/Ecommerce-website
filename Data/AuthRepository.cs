using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Dtos;
using ecommerce.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_website.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomer(string email)
        {
            // Fetch user by email 
            var query_user = await _context.Customer.FirstOrDefaultAsync(xxx => xxx.Email == email);
            return query_user;
        }

        public async Task<Customer> Register(CustomerToRegister customerToRegister)
        {
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
                await _context.Customer.AddAsync(newCustomer);
                await _context.SaveChangesAsync();
            return newCustomer;  
        }

        public async Task<bool> UserExists(string email)
        {
             if (await _context.Customer.AnyAsync(xxx => xxx.Email == email)) return true;
             else return false;
        }
    }
}