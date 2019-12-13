using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TheRange.Core.Entity.Mens
{
    public class Tops
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public string Sleeve { get; set; }
        public string Fit { get; set; }
        public Decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
