﻿using System;
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





        public static void SeedProductDetails(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>().HasData(
                new ProductDetails
                {
                    ProductDetailId = 1,
                    Name = "Dell XPS 15",
                    ProductId=1,
                    ImgUrl1= "https://slickdeals.net/blog/wp-content/uploads/2019/09/19-dell-xps-15-17.jpg",
                    ImgUrl2= "https://cdn.vox-cdn.com/thumbor/e5o-t8oG4U-dNlsGGfy366O9udU=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/19882265/dims.jpeg",
                    ImgUrl3= "https://www.slashgear.com/wp-content/uploads/2017/01/Dell13XPSConvertible-980x420.jpg",
                    OperatingSystem= "Windows 10 64-bit Edition",
                    Manufacturer= "Dell, Inc.",
                    Cpu= "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed= "3.3 GHz",
                    NumCores= "Quad-Core",
                    ChipsetType= "Mobile Intel HM87 Express",
                    CacheSize= "6 MB",
                    CacheType= "L3 cache",
                    Features= "Intel Turbo Boost Technology 2.0",
                    RamType= "DDR3L SDRAM 1600 MHz",
                    RamSize= "2 x 8 GB",
                    DisplayTech= "WLED backlight",
                    DisplayResolution= "3200 x 1800 (QHD+)",
                    DisplaySize= "39.6 cm",
                    DisplayType= "LED QHD+",
                    GraphicName= "NVIDIA GeForce GT 750M",
                    GraphicSize="4 GB",
                    Webcam="15 MPX",
                    Sound= "Stereo speakers, two microphones",
                    AudioCodec= "Realtek ALC3661",
                    HardDriveType="SSD",
                    HardDriveSize="1 TB",
                    InputType= "keyboard, touchpad",
                    WirelessProtocol= "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController= "Intel Dual Band Wireless-AC 7260",
                    Bluetooth="4.0",
                    CardReaderType= "3 in 1 card reader",
                    CardReaderSupport= "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize= "91 Wh",
                    BaterryCells= "6-cell",
                    Dimensions= "15.6 in",
                    Mainboard= "Mobile Intel HM87 Express",
                    Weight= "4.41 lbs",
                    Backlight="Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 2,
                    Name = "Macbook Pro 2020",
                    ProductId=2,
                    ImgUrl1= "http://pngimg.com/uploads/macbook/macbook_PNG76.png",
                    ImgUrl2= "https://9to5mac.com/wp-content/uploads/sites/6/2019/11/16-inch-MacBook-Pro-2019-1.jpg?quality=82&strip=all&w=1600",
                    ImgUrl3= "https://icdn2.digitaltrends.com/image/digitaltrends/watershed-moment-mac-behance-feat.jpg",
                    OperatingSystem= "Windows 10 64-bit Edition",
                    Manufacturer= "Dell, Inc.",
                    Cpu= "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed= "3.3 GHz",
                    NumCores= "Quad-Core",
                    ChipsetType= "Mobile Intel HM87 Express",
                    CacheSize= "6 MB",
                    CacheType= "L3 cache",
                    Features= "Intel Turbo Boost Technology 2.0",
                    RamType= "DDR3L SDRAM 1600 MHz",
                    RamSize= "2 x 8 GB",
                    DisplayTech= "WLED backlight",
                    DisplayResolution= "3200 x 1800 (QHD+)",
                    DisplaySize= "39.6 cm",
                    DisplayType= "LED QHD+",
                    GraphicName= "NVIDIA GeForce GT 750M",
                    GraphicSize="4 GB",
                    Webcam="15 MPX",
                    Sound= "Stereo speakers, two microphones",
                    AudioCodec= "Realtek ALC3661",
                    HardDriveType="SSD",
                    HardDriveSize="1 TB",
                    InputType= "keyboard, touchpad",
                    WirelessProtocol= "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController= "Intel Dual Band Wireless-AC 7260",
                    Bluetooth="4.0",
                    CardReaderType= "3 in 1 card reader",
                    CardReaderSupport= "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize= "91 Wh",
                    BaterryCells= "6-cell",
                    Dimensions= "15.6 in",
                    Mainboard= "Mobile Intel HM87 Express",
                    Weight= "4.41 lbs",
                    Backlight="Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 3,
                    Name = "HP Spectre X360 15",
                    ProductId = 3,
                    ImgUrl1 = "https://images.idgesg.net/images/article/2019/09/hp_spectre_x360_13_2019_main-100812335-large.jpg",
                    ImgUrl2 = "https://www.windowscentral.com/sites/wpcentral.com/files/styles/large/public/field/image/2019/09/hp-spectre-x360-13-late-2019-2.jpg?itok=hGFrfunO",
                    ImgUrl3 = "https://images-na.ssl-images-amazon.com/images/I/61nWrTKTAFL._AC_SX355_.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 4,
                    Name = "ASUS GL702 Gamming",
                    ProductId = 4,
                    ImgUrl1 = "https://edgeup.asus.com/wp-content/uploads/2016/09/gl702-back-696x464.jpg",
                    ImgUrl2 = "https://edgeup.asus.com/wp-content/uploads/2016/09/gl702-portsleft.jpg",
                    ImgUrl3 = "https://media.karousell.com/media/photos/products/2018/10/27/asus_rog_gl702_strix_1540621749_74d7529a.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 5,
                    Name = "HP Gamming Pavilion",
                    ProductId = 5,
                    ImgUrl1 = "https://target.scene7.com/is/image/Target/GUEST_1f1747c6-1c5c-4df5-839f-e118f52ca133?wid=488&hei=488&fmt=pjpeg",
                    ImgUrl2 = "https://cdn.mos.cms.futurecdn.net/4KtRHLkpg2skF9kmmPwJdV.jpg",
                    ImgUrl3 = "https://www.yangcanggih.com/wp-content/uploads/2019/11/HP-Pavilion-Gaming-15-dk0043tx-8-1200x800.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 6,
                    Name = "Acer Swift 7",
                    ProductId = 6,
                    ImgUrl1 = "https://cdn.pocket-lint.com/r/s/1200x/assets/images/148452-laptops-review-acer-swift-7-2019-image1-xusiciqa7b.jpg",
                    ImgUrl2 = "https://i.gadgets360cdn.com/large/acer_swift_7_angle_ndtv_1579179106000.jpg",
                    ImgUrl3 = "https://static.acer.com/up/Resource/Acer/Laptops/Swift_7/Overview/20190312/2019_Swift_7_KSP_5_640.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 7,
                    Name = "Dell Alienware 17",
                    ProductId = 7,
                    ImgUrl1 = "https://specials-images.forbesimg.com/imageserve/5d690dd768cb0a0008c0dd84/960x0.jpg?cropX1=0&cropX2=1500&cropY1=126&cropY2=1126",
                    ImgUrl2 = "https://www.pngitem.com/pimgs/m/415-4154082_transparent-alienware-laptop-png-dell-alienware-laptops-png.png",
                    ImgUrl3 = "https://www.pcgamesn.com/wp-content/uploads/legacy/Dell_Alienware_17_Intel_Core_i9.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 8,
                    Name = "MacbookAir 13",
                    ProductId = 8,
                    ImgUrl1 = "https://cnet3.cbsistatic.com/img/KEM_0EsoAP-9kOds2Fbal9Ww540=/1200x675/2017/08/14/ec0fa893-faf2-46c3-8933-6898773804ba/apple-macbook-air-2017-05.jpg",
                    ImgUrl2 = "https://icdn2.digitaltrends.com/image/digitaltrends/macbook-air-2020-02.jpg",
                    ImgUrl3 = "https://cdn.mos.cms.futurecdn.net/HvjfsxzQHCZxpUYTVgyBDM.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                },
                new ProductDetails
                {
                    ProductDetailId = 9,
                    Name = "LENOVO ThinkPad X1",
                    ProductId = 9,
                    ImgUrl1 = "https://cdn.mos.cms.futurecdn.net/UwsmVJaCfuRHBUnrLeN2XP.jpg",
                    ImgUrl2 = "https://laptopmedia.com/wp-content/uploads/2019/11/lenovothinkpadx1extremegen2featured.jpg",
                    ImgUrl3 = "https://i.redd.it/wy0nuwcxjfi31.jpg",
                    OperatingSystem = "Windows 10 64-bit Edition",
                    Manufacturer = "Dell, Inc.",
                    Cpu = "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz",
                    CpuSpeed = "3.3 GHz",
                    NumCores = "Quad-Core",
                    ChipsetType = "Mobile Intel HM87 Express",
                    CacheSize = "6 MB",
                    CacheType = "L3 cache",
                    Features = "Intel Turbo Boost Technology 2.0",
                    RamType = "DDR3L SDRAM 1600 MHz",
                    RamSize = "2 x 8 GB",
                    DisplayTech = "WLED backlight",
                    DisplayResolution = "3200 x 1800 (QHD+)",
                    DisplaySize = "39.6 cm",
                    DisplayType = "LED QHD+",
                    GraphicName = "NVIDIA GeForce GT 750M",
                    GraphicSize = "4 GB",
                    Webcam = "15 MPX",
                    Sound = "Stereo speakers, two microphones",
                    AudioCodec = "Realtek ALC3661",
                    HardDriveType = "SSD",
                    HardDriveSize = "1 TB",
                    InputType = "keyboard, touchpad",
                    WirelessProtocol = "802.11a/b/g/n/ac, Bluetooth 4.0, NFC",
                    WirelessController = "Intel Dual Band Wireless-AC 7260",
                    Bluetooth = "4.0",
                    CardReaderType = "3 in 1 card reader",
                    CardReaderSupport = "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card",
                    BatterySize = "91 Wh",
                    BaterryCells = "6-cell",
                    Dimensions = "15.6 in",
                    Mainboard = "Mobile Intel HM87 Express",
                    Weight = "4.41 lbs",
                    Backlight = "Yes"
                }
            );
        }
    }
}
