using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Model
{
    public class Customer
    {     
        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip5 { get; set; }
        public int Zip4 { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<CustomerShippingAddresses> CustomerShippingAddresses { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
