using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Order { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address1 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address2 { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string State { get; set; }
        public int Zip5 { get; set; }
        public int Zip4 { get; set; }
    }
}
