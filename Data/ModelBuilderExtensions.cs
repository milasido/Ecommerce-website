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
                    ProductName = "Dell XPS 15",
                    ProductPrice = 1399,
                    ProductImageUrl = "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",
                },
                new Products
                {
                    ProductId = 2,
                    ProductName = "Macbook Pro 2020",
                    ProductPrice = 1999,
                    ProductImageUrl = "http://pngimg.com/uploads/macbook/macbook_PNG76.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 3,
                    ProductName = "HP Spectre X360 15",
                    ProductPrice = 1849,
                    ProductImageUrl = "https://png2.cleanpng.com/sh/b8528a5e30d72245cdbbb8c45918877e/L0KzQYm4UcE3N6RnipH0aYP2gLBuTfhxNaR1fdV9cnWwiIS9TcE0NZJqReVucnnog37wjwRmdF5ohARuLXm6Pb3okQQucKEyiAJuY4T1dX7BU8YuOWQyedcALUP3hX7qiPVkc55mjNc2Y3BwgMa0VfJmbZI5S6NtZUW7QIi1UMk1PWM8UaY6NUS1Q4e9UsU4QWI1T5D5bne=/kisspng-hp-spectre-x36-13-ae-series-intel-core-i7-lapt-hp-spectre-x36-13-ae5-3tu-checkmate-compu-5beea431de5807.0945279415423662579107.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 4,
                    ProductName = "ASUS GL702 Gamming",
                    ProductPrice = 1499,
                    ProductImageUrl = "https://png2.cleanpng.com/sh/374245de3c2eea1a275400c98ec203f4/L0KzQYq3UcI2N5x1R91yc4Pzfri0ggN2e153h9k2c4T1ecm0kBNiel5ugZ9wbEWwRH7zggB1d6EyeeVAcz31f7i0hBFucZ8yTdU9YnHpc4WBhfM3amMzSqs9M0O5RoS4VcQ5PGc5SKgDNUi3SHB3jvc=/kisspng-asus-rog-strix-scar-ii-gl5-4-laptop-asus-rog-gamin-5c4bafc48ec6b2.2943366315484640685848.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 5,
                    ProductName = "HP Gaming Pavilion",
                    ProductPrice = 999,
                    ProductImageUrl = "https://png2.cleanpng.com/sh/e6616b48999baa49bc3dd3655cb77303/L0KzQYm3VsE4N6pmi5H0aYP2gLBuTfxieKV0iJ9qc4X2PcP2h710fKNukJ9wbEW4Q37wjwRmdF5ohARuLXm6Pbr6iP9xeJpzfAJ0LUXlQofrWMQ5Omk5SacBLkK0QoK7WcAzOWY3UaQCMkO8QoK9VMkveJ9s/kisspng-laptop-asus-rog-strix-gl553-intel-core-i7-ishoppingpk-5b26d848284156.2121490215292723921649.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 6,
                    ProductName = "Acer Swift 7",
                    ProductPrice = 1799,
                    ProductImageUrl = "https://static.acer.com/up/Resource/Acer/Laptops/Swift_7/Photogallery/20190322/Acer-Swift-7-SF714-52T-Black-photogallery-02.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 7,
                    ProductName = "Dell Alienware 17",
                    ProductPrice = 2999,
                    ProductImageUrl = "https://png2.cleanpng.com/sh/634af83ba7489df748a5b02f0ff0e2b0/L0KzQYm3VcE4N5xmfZH0aYP2gLBuTfxieKV0iJ9tZXzvPbLzifVvf5J3fZ86Nz31RH7rhfxtNZJxgdd3d3H1dX64V71zPF5oRadqZnS1QYS4VshjPWk6RqY7OUm5SIG3UcUzPmY4UKc9NUS1SIq1kP5o/kisspng-laptop-dell-alienware-17-r4-dell-alienware-17-r4-c-5afd213168b585.4299680015265385454289.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 8,
                    ProductName = "Macbook Air 13",
                    ProductPrice = 1299,
                    ProductImageUrl = "https://png2.cleanpng.com/sh/f9413eeafb234fe2d5961891ddd3a7c7/L0KzQYm3UsAzN5h8fZH0aYP2gLBuTf1ia5N0h902cILyPb7ogBlvfJD4gJ92YXPlf7FyTfFqel5xeeJ9b4CwfbLqgv9wc151htk2cHnmPYboV8U0QJdmStQDMkC0PoeCUsMyOWc4Sac6N0a2QYi6WME4QGMziNDw/kisspng-macbook-pro-macintosh-macbook-air-laptop-macbook-png-pic-5a7538fa2b8201.6923116315176317381782.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 9,
                    ProductName = "LENOVO Thinkpad X1",
                    ProductPrice = 1719,
                    ProductImageUrl = "https://png2.cleanpng.com/sh/75c27a763e0e2eacc4233bf572d6d185/L0KzQYm3WcI4N6t2kJH0aYP2gLBuTfxmdpD7h599aHnxe8HohL11PGcyiJ87LXb6PYK7TflvfJZxRdV4cnWweYa0jB4ue5JxfZ8AYnHnQoa8VvIybJY3S5CAOEe2QIm3V8E2O2k1T6UENEK6Qom9TwBvbz==/kisspng-lenovo-thinkpad-t46-p-2-fw-14-intel-core-i5-on-sale-5bad2556b1de23.5873080715380739427286.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                }
            );
        }    
    }
}
