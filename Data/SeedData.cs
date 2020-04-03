using System.Collections.Generic;
using System.Linq;
using ecommerce.Data;
using Newtonsoft.Json;
using ecommerce.Model;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace ecommerce.Data
{
    public class SeedData
    {
        public static void SeedCustomers(DataContext context)
        {
            // run seeddata only if no customer in database
            if(!context.Customer.Any())
            {
                // Read from the Seed Json file
                var customerData = System.IO.File.ReadAllText("Data/DummyCustomers.json");
                // Get a list of Customers 
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach (var user in customers)
                {
                    byte[] salted = new byte[128 / 8];
                    using (var rng = RandomNumberGenerator.Create())
                    {
                        rng.GetBytes(salted);
                    }
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: "password",
                        salt: salted,
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 10000,
                        numBytesRequested: 256 / 8));
                    // store password hashed for new customer
                    user.PasswordHashed = hashed;
                    user.PasswordSalt = salted;
                    user.DateCreated = DateTime.Now;
                    // add new customer to database
                    context.Customer.AddAsync(user);
                }
                context.SaveChanges();
            }
        }
    }
}
