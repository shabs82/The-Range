using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using TheRange.Core.Entity.Mens;

namespace TheRange.Core.Entity
{
    public class Order
    {
        public int id { get; set; }
        public Customer Customers { get; set; }//one order has one cust
        public List<Tops> Tops { get; set; }//one order has many umbrellas
        public List<Sweatshirts> Sweatshirts { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

