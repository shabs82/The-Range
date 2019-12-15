using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity.Mens;

namespace TheRange.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } 
        public List<Tops> Tops { get; set; }
        public List<Sweatshirts> Sweatshirts { get; set; }
    }
}
