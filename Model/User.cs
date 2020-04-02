using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastActive { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}
