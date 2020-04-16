using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Dtos
{
    public class CartToSave
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImageUrl { get; set; }
        public string productInformation { get; set; }
        public double productPrice { get; set; }
        public int quantity { get; set; }
        public int CustomerId { get; set; }
    }
}
