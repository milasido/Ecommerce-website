using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Controllers;
using ecommerce.Data;
using ecommerce.Dtos;
using ecommerce.Model;
using Ecommerce_website.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
namespace Ecommerce_website.Ecommerce_Unit_Test
{
    [TestFixture]
    public class HomeControllerTest
    {
        // Test get all products function in home controller 
        [Test]
        public void Test_GetAllProduct()
        {
            // Arrange: return a list of products
            Mock<IProductRepository> mockIProductRepository = new Mock<IProductRepository>();
            mockIProductRepository.Setup(repo => repo.GetAllProduct())
            .Returns(getProducts());
            var homeController = new HomeController(mockIProductRepository.Object);
            //Action: call Get all products in home controller 
            var res = homeController.GetAllProduct();
            // Assert: expect an Ok Object(Products)
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkObjectResult>(res);
        }
        // Test get product by id function in home controller
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(11)]
        public async Task Test_GetOneProduct(int id) 
        {
            //Arrage 
            Mock<IProductRepository> mockIProductRepository = new Mock<IProductRepository>();
            mockIProductRepository.Setup(repo => repo.GetOneProduct(id))
            .Returns(Task.FromResult(new Products()));
            var homeController = new HomeController(mockIProductRepository.Object);
            //Action: call Get one product in home controller 
            var res = await homeController.GetOneProduct(id);
            // Assert: expect an Ok with 1 Product
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkObjectResult>(res);
        }
        // Test get product detail by id function in home controller
        [TestCase(2)]
        [TestCase(41)]
        [TestCase(11111)]
        public async Task Test_ProductDetail(int id) 
        {
            //Arrage : Get Product Detail return one product 
            Mock<IProductRepository> mockIProductRepository = new Mock<IProductRepository>();
            mockIProductRepository.Setup(repo => repo.GetProductDetail(id))
            .Returns(Task.FromResult(new ProductDetails()));
            var homeController = new HomeController(mockIProductRepository.Object);
            //Action: call Get one product in home controller 
            var res = await homeController.GetProductDetail(id);
            // Assert: expect an Ok with 1 Product Detail
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkObjectResult>(res);
        }
        private List<Products> getProducts() {
            var product_1 = new Products();
            var product_2 = new Products();
            var list_products = new List<Products>();
            list_products.Add(product_1);
            list_products.Add(product_2);
            return list_products;
        }
    }
}