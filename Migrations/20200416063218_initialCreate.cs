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
                    Quantity = table.Column<int>(nullable: false),
                    SalePrice = table.Column<int>(nullable: false),
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
                values: new object[] { 1, "8200 broadway st", "apt 711n", "houston", new DateTime(2020, 4, 16, 1, 32, 18, 267, DateTimeKind.Local).AddTicks(7288), "wolnguyen98@gmail.com", "thuy nguyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZNkKTAUlzM2u1t9g2KZFQ9Ypxe4iYzpUZGlN4vhdSs=", new byte[] { 164, 87, 47, 117, 244, 231, 185, 157, 1, 73, 0, 212, 49, 5, 247, 51 }, "tx", "", "" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 2, "8956 Sage St", "", "Benton Harbor", new DateTime(2020, 4, 16, 1, 32, 18, 272, DateTimeKind.Local).AddTicks(2390), "cmphan7@gmail.com", "cuong phan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZNkKTAUlzM2u1t9g2KZFQ9Ypxe4iYzpUZGlN4vhdSs=", new byte[] { 164, 87, 47, 117, 244, 231, 185, 157, 1, 73, 0, 212, 49, 5, 247, 51 }, "MI", "", "49022" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 3, "457 Illinois Road", "", "Monsey", new DateTime(2020, 4, 16, 1, 32, 18, 272, DateTimeKind.Local).AddTicks(2466), "kimnguyen137@gmail.com", "kim nguyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZNkKTAUlzM2u1t9g2KZFQ9Ypxe4iYzpUZGlN4vhdSs=", new byte[] { 164, 87, 47, 117, 244, 231, 185, 157, 1, 73, 0, 212, 49, 5, 247, 51 }, "ny", "", "10952" });

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
                values: new object[] { 3, "https://png2.cleanpng.com/sh/b8528a5e30d72245cdbbb8c45918877e/L0KzQYm4UcE3N6RnipH0aYP2gLBuTfhxNaR1fdV9cnWwiIS9TcE0NZJqReVucnnog37wjwRmdF5ohARuLXm6Pb3okQQucKEyiAJuY4T1dX7BU8YuOWQyedcALUP3hX7qiPVkc55mjNc2Y3BwgMa0VfJmbZI5S6NtZUW7QIi1UMk1PWM8UaY6NUS1Q4e9UsU4QWI1T5D5bne=/kisspng-hp-spectre-x36-13-ae-series-intel-core-i7-lapt-hp-spectre-x36-13-ae5-3tu-checkmate-compu-5beea431de5807.0945279415423662579107.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "HP Spectre X360 15", 1849.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 4, "https://png2.cleanpng.com/sh/374245de3c2eea1a275400c98ec203f4/L0KzQYq3UcI2N5x1R91yc4Pzfri0ggN2e153h9k2c4T1ecm0kBNiel5ugZ9wbEWwRH7zggB1d6EyeeVAcz31f7i0hBFucZ8yTdU9YnHpc4WBhfM3amMzSqs9M0O5RoS4VcQ5PGc5SKgDNUi3SHB3jvc=/kisspng-asus-rog-strix-scar-ii-gl5-4-laptop-asus-rog-gamin-5c4bafc48ec6b2.2943366315484640685848.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "ASUS GL702 Gamming", 1499.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 5, "https://png2.cleanpng.com/sh/e6616b48999baa49bc3dd3655cb77303/L0KzQYm3VsE4N6pmi5H0aYP2gLBuTfxieKV0iJ9qc4X2PcP2h710fKNukJ9wbEW4Q37wjwRmdF5ohARuLXm6Pbr6iP9xeJpzfAJ0LUXlQofrWMQ5Omk5SacBLkK0QoK7WcAzOWY3UaQCMkO8QoK9VMkveJ9s/kisspng-laptop-asus-rog-strix-gl553-intel-core-i7-ishoppingpk-5b26d848284156.2121490215292723921649.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "HP Gaming Pavilion", 999.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 6, "https://static.acer.com/up/Resource/Acer/Laptops/Swift_7/Photogallery/20190322/Acer-Swift-7-SF714-52T-Black-photogallery-02.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Acer Swift 7", 1799.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 7, "https://png2.cleanpng.com/sh/634af83ba7489df748a5b02f0ff0e2b0/L0KzQYm3VcE4N5xmfZH0aYP2gLBuTfxieKV0iJ9tZXzvPbLzifVvf5J3fZ86Nz31RH7rhfxtNZJxgdd3d3H1dX64V71zPF5oRadqZnS1QYS4VshjPWk6RqY7OUm5SIG3UcUzPmY4UKc9NUS1SIq1kP5o/kisspng-laptop-dell-alienware-17-r4-dell-alienware-17-r4-c-5afd213168b585.4299680015265385454289.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell Alienware 17", 2999.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 8, "https://png2.cleanpng.com/sh/f9413eeafb234fe2d5961891ddd3a7c7/L0KzQYm3UsAzN5h8fZH0aYP2gLBuTf1ia5N0h902cILyPb7ogBlvfJD4gJ92YXPlf7FyTfFqel5xeeJ9b4CwfbLqgv9wc151htk2cHnmPYboV8U0QJdmStQDMkC0PoeCUsMyOWc4Sac6N0a2QYi6WME4QGMziNDw/kisspng-macbook-pro-macintosh-macbook-air-laptop-macbook-png-pic-5a7538fa2b8201.6923116315176317381782.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Macbook Air 13", 1299.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 9, "https://png2.cleanpng.com/sh/75c27a763e0e2eacc4233bf572d6d185/L0KzQYm3WcI4N6t2kJH0aYP2gLBuTfxmdpD7h599aHnxe8HohL11PGcyiJ87LXb6PYK7TflvfJZxRdV4cnWweYa0jB4ue5JxfZ8AYnHnQoa8VvIybJY3S5CAOEe2QIm3V8E2O2k1T6UENEK6Qom9TwBvbz==/kisspng-lenovo-thinkpad-t46-p-2-fw-14-intel-core-i5-on-sale-5bad2556b1de23.5873080715380739427286.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "LENOVO Thinkpad X1", 1719.0 });

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
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                unique: true);
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
