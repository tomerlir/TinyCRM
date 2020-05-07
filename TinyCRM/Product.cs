using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCRM
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductCatergory { get; set; }

        public Product()
        {
        }
    }
}