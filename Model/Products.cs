using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ProductPrice { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ProductImgUrl { get; set; }
      
    }
}
