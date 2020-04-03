using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;

namespace ecommerce.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }    
        public string ProductInformation { get; set; }
        public int ProductDetailId { get; set; }
        public ProductDetails productDetails { get; set; }
    }
}
