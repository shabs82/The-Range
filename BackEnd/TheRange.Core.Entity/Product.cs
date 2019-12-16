using System;
using System.Collections.Generic;
using System.Text;

namespace TheRange.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public Order Order { get; set; }
    }
}
