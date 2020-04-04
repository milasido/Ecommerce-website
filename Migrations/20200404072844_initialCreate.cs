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
                    Backlight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailId);
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
                    CustomerId = table.Column<int>(nullable: false),
                    OrderDetailId = table.Column<int>(nullable: false)
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
                name: "OrderDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetailProductQuantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    OrdersOrderId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
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
                    ProductInformation = table.Column<string>(nullable: true),
                    ProductDetailId = table.Column<int>(nullable: false),
                    productDetailsProductDetailId = table.Column<int>(nullable: true),
                    OrderDetailsDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_OrderDetails_OrderDetailsDetailId",
                        column: x => x.OrderDetailsDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductDetails_productDetailsProductDetailId",
                        column: x => x.productDetailsProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "ProductDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 1, "8200 broadway st", "apt 711n", "houston", new DateTime(2020, 4, 4, 2, 28, 43, 662, DateTimeKind.Local).AddTicks(9685), "wolnguyen98@gmail.com", "thuy nguyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "atp/aKVvAH2L7d7Y6ujdnep7UkzLLdDMyiiowaX5K2M=", new byte[] { 43, 1, 212, 161, 174, 125, 47, 73, 147, 39, 122, 90, 102, 157, 58, 134 }, "tx", "", "" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 2, "8956 Sage St", "", "Benton Harbor", new DateTime(2020, 4, 4, 2, 28, 43, 667, DateTimeKind.Local).AddTicks(4386), "cmphan7@gmail.com", "cuong phan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "atp/aKVvAH2L7d7Y6ujdnep7UkzLLdDMyiiowaX5K2M=", new byte[] { 43, 1, 212, 161, 174, 125, 47, 73, 147, 39, 122, 90, 102, 157, 58, 134 }, "MI", "", "49022" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt", "State", "Zip4", "Zip5" },
                values: new object[] { 3, "457 Illinois Road", "", "Monsey", new DateTime(2020, 4, 4, 2, 28, 43, 667, DateTimeKind.Local).AddTicks(4453), "kimnguyen137@gmail.com", "kim nguyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "atp/aKVvAH2L7d7Y6ujdnep7UkzLLdDMyiiowaX5K2M=", new byte[] { 43, 1, 212, 161, 174, 125, 47, 73, 147, 39, 122, 90, 102, 157, 58, 134 }, "ny", "", "10952" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 1, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 2, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 3, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 4, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 5, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 6, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 7, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 8, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OrderDetailsDetailId", "ProductDetailId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice", "productDetailsProductDetailId" },
                values: new object[] { 9, null, 1, "https://i.dell.com/sites/csimages/Video_Imagery/all/xps_7590_touch.png", "The world’s smallest 15.6-inch performance laptop with a stunning OLED display option. Now featuring 9th Gen Intel® Core™ processors.", "Dell xps 15", 1000.0, null });

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
                name: "IX_CustomerShippingAddresses_CustomerId",
                table: "CustomerShippingAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrdersOrderId",
                table: "OrderDetails",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderDetailsDetailId",
                table: "Products",
                column: "OrderDetailsDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productDetailsProductDetailId",
                table: "Products",
                column: "productDetailsProductDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerShippingAddresses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
