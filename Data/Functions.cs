using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Data
{
    public class Functions
    {
        //Function Hash password give hashed password and salted password
        public void HashPassword(string pass, out byte[] salted, out string hashed)
        {
            salted = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salted);
            }
            hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salted,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }

}