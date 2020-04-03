using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Model
{
    public class OrderDetails
    {
        [Key]
        public int DetailId { get; set; }
        public string DetailProductName { get; set; }
        public string DetailProductPrice { get; set; }
        public int DetailProductQuantity { get; set; }
        public int DetailOrderId { get; set; }
        public int DetailProductId { get; set; }
        public int ProductId { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
