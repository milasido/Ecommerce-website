using System;
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
    public class AuthControllerTest
    {
        // Test Register method in AuthController Class
        // Expect a 201 -> successfully register
        [TestCase("emailToTest", "passwordToTest")]
        public async Task Register_Successful_ResponseStatusCode201(string email, string password)
        {
            Mock<IAuthRepository> mockIAuthRepository = new Mock<IAuthRepository>();
            Mock<IOptions<ApplicationSettings>> mockIOptions_ApllicationSettings = new Mock<IOptions<ApplicationSettings>>();
            var customerToRegister = new CustomerToRegister() {
                Email = email,
                Password = password
            };
            // Set up default return from repo
            mockIAuthRepository.Setup(repo => repo.UserExists(It.IsAny<String>()))
            .Returns(Task.FromResult(false)); // false -> email not existed in system -> user able to register 
            mockIAuthRepository.Setup(repo => repo.Register(It.IsAny<CustomerToRegister>()))
            .ReturnsAsync(new Customer()); // return new user when register successfully 
            var authController = new AuthController(mockIAuthRepository.Object, mockIOptions_ApllicationSettings.Object);
            // Get a status code reponse back from call register method in auth controller
            var statusCode = await authController.Register(customerToRegister);
            // Expect 201 
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.StatusCodeResult>(statusCode);
        }
        // Test Register method in AuthController Class
        // Expect a BadRequest -> email has already been used 
        [TestCase("emailToTest", "passwordToTest")]
        public async Task Register_Fail_Email_AlreadyUsed_ResponseBadRequest(string email, string password)
        {
            Mock<IAuthRepository> mockIAuthRepository = new Mock<IAuthRepository>();
            Mock<IOptions<ApplicationSettings>> mockIOptions_ApllicationSettings = new Mock<IOptions<ApplicationSettings>>();
            var customerToRegister = new CustomerToRegister() {
                Email = email,
                Password = password
            };
            // Set up default return from repo
            mockIAuthRepository.Setup(repo => repo.UserExists(It.IsAny<String>()))
            .Returns(Task.FromResult(true)); // true -> email has already existed in system -> user cannot register 
            var authController = new AuthController(mockIAuthRepository.Object, mockIOptions_ApllicationSettings.Object);
            // Get a status code reponse back from call register method in auth controller
            var statusCode = await authController.Register(customerToRegister);
            // Expect Bad Request instance
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(statusCode);
        }
        //Test Login Method => return bad request for user name and password 
         [TestCase("emailToLogin", "passwordToLogin")]
        public async Task Login_Failure_ResponseBadRequest(string email, string password)
        {
            var customerToLogin = new CustomerToLogin() {
                Email = email,
                Password = password
            };
            Mock<IAuthRepository> mockIAuthRepository = new Mock<IAuthRepository>();
            Mock<IOptions<ApplicationSettings>> mockIOptions_ApllicationSettings = new Mock<IOptions<ApplicationSettings>>();
            // User does not exist in the system 
            mockIAuthRepository.Setup(repo => repo.UserExists(It.IsAny<string>()))
            .ReturnsAsync(false);
            var authController = new AuthController(mockIAuthRepository.Object, mockIOptions_ApllicationSettings.Object);
            var response = await authController.Login(customerToLogin);
            // Assert: Expect a Bad Request
            Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(response);
        }
    }
}