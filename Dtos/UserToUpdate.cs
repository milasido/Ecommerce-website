using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Dtos
{
    public class UserToUpdate
    {
        public string fullname { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string zip5 { get; set; }
        public string password { get; set; }
        public string password2 { get; set; }
        public string zip4 { get; set; }

    }
}
