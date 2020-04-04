using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ecommerce.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedCustomers(this ModelBuilder modelBuilder)
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


            _ = modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Fullname = "thuy nguyen",
                    Email = "wolnguyen98@gmail.com",
                    PasswordHashed = hashed,
                    PasswordSalt = salted,
                    Address1 = "8200 broadway st",
                    Address2 = "apt 711n",
                    City = "houston",
                    State = "tx",
                    Zip5 = "",
                    Zip4 = "",
                    DateCreated = DateTime.Now
                    
                },
                new Customer
                {
                    CustomerId = 2,
                    Fullname = "cuong phan",
                    Email = "cmphan7@gmail.com",
                    PasswordHashed = hashed,
                    PasswordSalt = salted,
                    Address1 = "8956 Sage St",
                    Address2 = "",
                    City = "Benton Harbor",
                    State = "MI",
                    Zip5 = "49022",
                    Zip4 = "",
                    DateCreated = DateTime.Now
                },
                new Customer
                {
                    CustomerId = 3,
                    Fullname = "kim nguyen",
                    Email = "kimnguyen137@gmail.com",
                    PasswordHashed = hashed,
                    PasswordSalt = salted,
                    Address1 = "457 Illinois Road",
                    Address2 = "",
                    City = "Monsey",
                    State = "ny",
                    Zip5 = "10952",
                    Zip4 = "",
                    DateCreated = DateTime.Now
                }
            );
        }

        public static void SeedShippingAddressBook(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerShippingAddresses>().HasData(
                new CustomerShippingAddresses
                {
                    CustomerId = 1,
                    ShippingId = 1,
                    Name = "thuy nguyen",                    
                    Address1 = "8220 broadway",
                    Address2 = "apt 711n",
                    City = "houston",
                    State = "tx",
                    Zip5 = "77061",
                    Zip4 = "1233"                 
                },
                new CustomerShippingAddresses
                {
                    CustomerId = 1,
                    ShippingId = 2,
                    Name = "chau nguyen",
                    Address1 = "8220 broadway",
                    Address2 = "apt 709n",
                    City = "houston",
                    State = "tx",
                    Zip5 = "77061",
                    Zip4 = "1233"
                },
                new CustomerShippingAddresses
                {
                    CustomerId = 2,
                    ShippingId = 3,
                    Name = "cuong nguyen",
                    Address1 = "921 Trucklemans Lane",
                    Address2 = "",
                    City = "Brookfield",
                    State = "ca",
                    Zip5 = "665501",
                    Zip4 = ""
                },
                new CustomerShippingAddresses
                {
                    CustomerId = 2,
                    ShippingId = 4,
                    Name = "cuong phan",
                    Address1 = "8956 Sage St",
                    Address2 = "",
                    City = "Benton Harbor",
                    State = "MI ",
                    Zip5 = "49022",
                    Zip4 = ""
                },
                new CustomerShippingAddresses
                {
                    CustomerId = 3,
                    ShippingId = 5,
                    Name = "kim phan",
                    Address1 = "339 East Thompson Court",
                    Address2 = "",
                    City = "Beaver Falls",
                    State = "PA ",
                    Zip5 = "15010",
                    Zip4 = ""
                },
                new CustomerShippingAddresses
                {
                    CustomerId = 3,
                    ShippingId = 6,
                    Name = "kim nguyen",
                    Address1 = "457 Illinois Road",
                    Address2 = "218 Village Road",
                    City = "Brookfield",
                    State = "ca",
                    Zip5 = "665501",
                    Zip4 = ""
                }
            );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductId = 1,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 2,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 3,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 4,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 5,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 6,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 7,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 8,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                },
                new Products
                {
                    ProductId = 9,
                    ProductName = "Dell xps 15",
                    ProductPrice = 1000,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                    ProductDetailId = 1
                }
            );
        }    
    }
}
