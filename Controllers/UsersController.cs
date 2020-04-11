using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            // take user from database who has customerId  = {id}
            var user = await _dataContext.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);
            return Ok(user);
        }
    }
}