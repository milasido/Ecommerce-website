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
                    ProductImageUrl = "https://i.ibb.co/8Kx8JkM/spectre.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 4,
                    ProductName = "ASUS GL702 Gamming",
                    ProductPrice = 1499,
                    ProductImageUrl = "https://i.ibb.co/pvv6H0G/asus.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 5,
                    ProductName = "HP Gaming Pavilion",
                    ProductPrice = 999,
                    ProductImageUrl = "https://i.ibb.co/cD5QTZ5/hpgame.png",
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
                    ProductImageUrl = "https://i.ibb.co/zxf2JHh/alien.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 8,
                    ProductName = "Macbook Air 13",
                    ProductPrice = 1299,
                    ProductImageUrl = "https://i.ibb.co/4gypLd8/macair.png",
                    ProductInformation = "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.",

                },
                new Products
                {
                    ProductId = 9,
                    ProductName = "LENOVO Thinkpad X1",
                    ProductPrice = 1719,
                    ProductImageUrl = "https://i.ibb.co/Cm5F0fD/lenovo.png",
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
