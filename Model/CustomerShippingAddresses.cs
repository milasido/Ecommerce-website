using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Model
{
    public class CustomerShippingAddresses
    {
        [Key]
        public int ShippingId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip5 { get; set; }
        public string Zip4 { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
