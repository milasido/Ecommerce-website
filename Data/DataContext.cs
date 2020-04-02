using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }
        public DbSet<Customer> Customer { get; set; }

        public static implicit operator DataContext(Customer v)
        {
            throw new NotImplementedException();
        }
    }
}
