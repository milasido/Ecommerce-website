using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Dtos;
using ecommerce.Model;

namespace ecommerce.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private Address _address;
        public TestController(Address address)
        {
            _address = address;
        }
        [HttpPost("validate")]
        public async Task<IActionResult> Validate([FromForm] AddressToValidate addressToValidate)
        {         
            var Result = new Address()
            {
                Name = addressToValidate.Name,
                Address1 = addressToValidate.Address1,
                Address2 = addressToValidate.Address2,
                City = addressToValidate.City,
                State = addressToValidate.State,
                Zip5 = addressToValidate.Zip5,
                Zip4 = addressToValidate.Zip4
            };

            return Ok(Result);

        }
    }
}