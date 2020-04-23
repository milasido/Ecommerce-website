using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Dtos;

namespace ecommerce.Model
{
    public class OrderToSave
    {
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip5 { get; set; }
        public string zip4 { get; set; }
        public string cardname { get; set; }
        public string cardnumber { get; set; }
        public List<CartToSave> detail{ get; set; }
    }
}