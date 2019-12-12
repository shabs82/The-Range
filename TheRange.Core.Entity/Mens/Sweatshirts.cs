using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TheRange.Core.Entity.Mens
{
    public class Sweatshirts
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public string Pattern { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
