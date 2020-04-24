using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fullname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHashed = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip5 = table.Column<string>(nullable: true),
                    Zip4 = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductImageUrl = table.Column<string>(nullable: true),
                    ProductInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productId = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: true),
                    productImageUrl = table.Column<string>(nullable: true),
                    productInformation = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    productPrice = table.Column<double>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerShippingAddresses",
                columns: table => new
                {
                    ShippingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip5 = table.Column<string>(nullable: true),
                    Zip4 = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerShippingAddresses", x => x.ShippingId);
                    table.ForeignKey(
                        name: "FK_CustomerShippingAddresses_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderName = table.Column<string>(nullable: true),
                    OrderShipAddress1 = table.Column<string>(nullable: true),
                    OrderShipAddress2 = table.Column<string>(nullable: true),
                    OrderShipCity = table.Column<string>(nullable: true),
                    OrderShipState = table.Column<string>(nullable: true),
                    OrderShipZip5 = table.Column<string>(nullable: true),
                    OrderShipZip4 = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<double>(nullable: false),
                    NumberOfItems = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl1 = table.Column<string>(nullable: true),
                    ImgUrl2 = table.Column<string>(nullable: true),
                    ImgUrl3 = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Cpu = table.Column<string>(nullable: true),
                    CpuSpeed = table.Column<string>(nullable: true),
                    NumCores = table.Column<string>(nullable: true),
                    CacheType = table.Column<string>(nullable: true),
                    CacheSize = table.Column<string>(nullable: true),
                    ChipsetType = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    RamType = table.Column<string>(nullable: true),
                    RamSpeed = table.Column<string>(nullable: true),
                    RamSize = table.Column<string>(nullable: true),
                    DisplayTech = table.Column<string>(nullable: true),
                    DisplayResolution = table.Column<string>(nullable: true),
                    DisplaySize = table.Column<string>(nullable: true),
                    DisplayType = table.Column<string>(nullable: true),
                    GraphicName = table.Column<string>(nullable: true),
                    GraphicSize = table.Column<string>(nullable: true),
                    Webcam = table.Column<string>(nullable: true),
                    Sound = table.Column<string>(nullable: true),
                    AudioCodec = table.Column<string>(nullable: true),
                    HardDriveType = table.Column<string>(nullable: true),
                    HardDriveSize = table.Column<string>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    WirelessProtocol = table.Column<string>(nullable: true),
                    WirelessController = table.Column<string>(nullable: true),
                    Bluetooth = table.Column<string>(nullable: true),
                    CardReaderType = table.Column<string>(nullable: true),
                    CardReaderSupport = table.Column<string>(nullable: true),
                    BatterySize = table.Column<string>(nullable: true),
                    BaterryCells = table.Column<string>(nullable: true),
                    Dimensions = table.Column<string>(nullable: true),
                    Mainboard = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Backlight = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailId);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductUrl = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SalePrice = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 1, "8200 broadway st", "apt 711n", "houston", new DateTime(2020, 4, 24, 13, 54, 13, 87, DateTimeKind.Local).AddTicks(3054), "wolnguyen98@gmail.com", "thuy nguyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "85UPoIIFby6fy3zmyv6A1i3Ql/vWS/fm6dPSIAA4E0Q=", new byte[] { 126, 0, 129, 32, 94, 237, 68, 93, 28, 48, 51, 120, 133, 48, 197, 88 }, "tx", "", "" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 2, "8956 Sage St", "", "Benton Harbor", new DateTime(2020, 4, 24, 13, 54, 13, 91, DateTimeKind.Local).AddTicks(1623), "cmphan7@gmail.com", "cuong phan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "85UPoIIFby6fy3zmyv6A1i3Ql/vWS/fm6dPSIAA4E0Q=", new byte[] { 126, 0, 129, 32, 94, 237, 68, 93, 28, 48, 51, 120, 133, 48, 197, 88 }, "MI", "", "49022" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 3, "457 Illinois Road", "", "Monsey", new DateTime(2020, 4, 24, 13, 54, 13, 91, DateTimeKind.Local).AddTicks(1673), "kimnguyen137@gmail.com", "kim nguyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "85UPoIIFby6fy3zmyv6A1i3Ql/vWS/fm6dPSIAA4E0Q=", new byte[] { 126, 0, 129, 32, 94, 237, 68, 93, 28, 48, 51, 120, 133, 48, 197, 88 }, "ny", "", "10952" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell XPS 15", 1399.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 2, "http://pngimg.com/uploads/macbook/macbook_PNG76.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Macbook Pro 2020", 1999.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 3, "https://i.ibb.co/8Kx8JkM/spectre.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "HP Spectre X360 15", 1849.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 4, "https://i.ibb.co/pvv6H0G/asus.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "ASUS GL702 Gamming", 1499.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 5, "https://i.ibb.co/cD5QTZ5/hpgame.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "HP Gaming Pavilion", 999.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 6, "https://static.acer.com/up/Resource/Acer/Laptops/Swift_7/Photogallery/20190322/Acer-Swift-7-SF714-52T-Black-photogallery-02.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Acer Swift 7", 1799.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 7, "https://i.ibb.co/zxf2JHh/alien.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell Alienware 17", 2999.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 8, "https://i.ibb.co/4gypLd8/macair.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Macbook Air 13", 1299.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 9, "https://i.ibb.co/Cm5F0fD/lenovo.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "LENOVO Thinkpad X1", 1719.0 });

            migrationBuilder.InsertData(
                table: "CustomerShippingAddresses",
                columns: new[] { "ShippingId", "Address1", "Address2", "City", "CustomerId", "Name", "State", "Zip4", "Zip5" },
                values: new object[] { 1, "8220 broadway", "apt 711n", "houston", 1, "thuy nguyen", "tx", "1233", "77061" });

            migrationBuilder.InsertData(
                table: "CustomerShippingAddresses",
                columns: new[] { "ShippingId", "Address1", "Address2", "City", "CustomerId", "Name", "State", "Zip4", "Zip5" },
                values: new object[] { 2, "8220 broadway", "apt 709n", "houston", 1, "chau nguyen", "tx", "1233", "77061" });

            migrationBuilder.InsertData(
                table: "CustomerShippingAddresses",
                columns: new[] { "ShippingId", "Address1", "Address2", "City", "CustomerId", "Name", "State", "Zip4", "Zip5" },
                values: new object[] { 3, "921 Trucklemans Lane", "", "Brookfield", 2, "cuong nguyen", "ca", "", "665501" });

            migrationBuilder.InsertData(
                table: "CustomerShippingAddresses",
                columns: new[] { "ShippingId", "Address1", "Address2", "City", "CustomerId", "Name", "State", "Zip4", "Zip5" },
                values: new object[] { 4, "8956 Sage St", "", "Benton Harbor", 2, "cuong phan", "MI ", "", "49022" });

            migrationBuilder.InsertData(
                table: "CustomerShippingAddresses",
                columns: new[] { "ShippingId", "Address1", "Address2", "City", "CustomerId", "Name", "State", "Zip4", "Zip5" },
                values: new object[] { 5, "339 East Thompson Court", "", "Beaver Falls", 3, "kim phan", "PA ", "", "15010" });

            migrationBuilder.InsertData(
                table: "CustomerShippingAddresses",
                columns: new[] { "ShippingId", "Address1", "Address2", "City", "CustomerId", "Name", "State", "Zip4", "Zip5" },
                values: new object[] { 6, "457 Illinois Road", "218 Village Road", "Brookfield", 3, "kim nguyen", "ca", "", "665501" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 1, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://slickdeals.net/blog/wp-content/uploads/2019/09/19-dell-xps-15-17.jpg", "https://cdn.vox-cdn.com/thumbor/e5o-t8oG4U-dNlsGGfy366O9udU=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/19882265/dims.jpeg", "https://www.slashgear.com/wp-content/uploads/2017/01/Dell13XPSConvertible-980x420.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "Dell XPS 15", "Quad-Core", "Windows 10 64-bit Edition", 1, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 2, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "http://pngimg.com/uploads/macbook/macbook_PNG76.png", "https://9to5mac.com/wp-content/uploads/sites/6/2019/11/16-inch-MacBook-Pro-2019-1.jpg?quality=82&strip=all&w=1600", "https://icdn2.digitaltrends.com/image/digitaltrends/watershed-moment-mac-behance-feat.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "Macbook Pro 2020", "Quad-Core", "Windows 10 64-bit Edition", 2, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 3, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://images.idgesg.net/images/article/2019/09/hp_spectre_x360_13_2019_main-100812335-large.jpg", "https://www.windowscentral.com/sites/wpcentral.com/files/styles/large/public/field/image/2019/09/hp-spectre-x360-13-late-2019-2.jpg?itok=hGFrfunO", "https://images-na.ssl-images-amazon.com/images/I/61nWrTKTAFL._AC_SX355_.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "HP Spectre X360 15", "Quad-Core", "Windows 10 64-bit Edition", 3, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 4, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://edgeup.asus.com/wp-content/uploads/2016/09/gl702-back-696x464.jpg", "https://edgeup.asus.com/wp-content/uploads/2016/09/gl702-portsleft.jpg", "https://media.karousell.com/media/photos/products/2018/10/27/asus_rog_gl702_strix_1540621749_74d7529a.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "ASUS GL702 Gamming", "Quad-Core", "Windows 10 64-bit Edition", 4, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 5, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://target.scene7.com/is/image/Target/GUEST_1f1747c6-1c5c-4df5-839f-e118f52ca133?wid=488&hei=488&fmt=pjpeg", "https://cdn.mos.cms.futurecdn.net/4KtRHLkpg2skF9kmmPwJdV.jpg", "https://www.yangcanggih.com/wp-content/uploads/2019/11/HP-Pavilion-Gaming-15-dk0043tx-8-1200x800.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "HP Gamming Pavilion", "Quad-Core", "Windows 10 64-bit Edition", 5, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 6, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://cdn.pocket-lint.com/r/s/1200x/assets/images/148452-laptops-review-acer-swift-7-2019-image1-xusiciqa7b.jpg", "https://i.gadgets360cdn.com/large/acer_swift_7_angle_ndtv_1579179106000.jpg", "https://static.acer.com/up/Resource/Acer/Laptops/Swift_7/Overview/20190312/2019_Swift_7_KSP_5_640.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "Acer Swift 7", "Quad-Core", "Windows 10 64-bit Edition", 6, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 7, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://specials-images.forbesimg.com/imageserve/5d690dd768cb0a0008c0dd84/960x0.jpg?cropX1=0&cropX2=1500&cropY1=126&cropY2=1126", "https://www.pngitem.com/pimgs/m/415-4154082_transparent-alienware-laptop-png-dell-alienware-laptops-png.png", "https://www.pcgamesn.com/wp-content/uploads/legacy/Dell_Alienware_17_Intel_Core_i9.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "Dell Alienware 17", "Quad-Core", "Windows 10 64-bit Edition", 7, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 8, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://cnet3.cbsistatic.com/img/KEM_0EsoAP-9kOds2Fbal9Ww540=/1200x675/2017/08/14/ec0fa893-faf2-46c3-8933-6898773804ba/apple-macbook-air-2017-05.jpg", "https://icdn2.digitaltrends.com/image/digitaltrends/macbook-air-2020-02.jpg", "https://cdn.mos.cms.futurecdn.net/HvjfsxzQHCZxpUYTVgyBDM.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "MacbookAir 13", "Quad-Core", "Windows 10 64-bit Edition", 8, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 9, "Realtek ALC3661", "Yes", "6-cell", "91 Wh", "4.0", "6 MB", "L3 cache", "SD Memory Card, SDHC Memory Card, SDIO, SDXC UHS Memory Card", "3 in 1 card reader", "Mobile Intel HM87 Express", "Intel Core i7 (4th Gen) 4712HQ / 2.3 GHz", "3.3 GHz", "15.6 in", "3200 x 1800 (QHD+)", "39.6 cm", "WLED backlight", "LED QHD+", "Intel Turbo Boost Technology 2.0", "NVIDIA GeForce GT 750M", "4 GB", "1 TB", "SSD", "https://cdn.mos.cms.futurecdn.net/UwsmVJaCfuRHBUnrLeN2XP.jpg", "https://laptopmedia.com/wp-content/uploads/2019/11/lenovothinkpadx1extremegen2featured.jpg", "https://i.redd.it/wy0nuwcxjfi31.jpg", "keyboard, touchpad", "Mobile Intel HM87 Express", "Dell, Inc.", "LENOVO ThinkPad X1", "Quad-Core", "Windows 10 64-bit Edition", 9, "2 x 8 GB", null, "DDR3L SDRAM 1600 MHz", "Stereo speakers, two microphones", "15 MPX", "4.41 lbs", "Intel Dual Band Wireless-AC 7260", "802.11a/b/g/n/ac, Bluetooth 4.0, NFC" });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShippingAddresses_CustomerId",
                table: "CustomerShippingAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "CustomerShippingAddresses");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
