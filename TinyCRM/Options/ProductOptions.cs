using System;
using System.Linq;
using TinyCrm;

namespace TinyCRM
{
    public class ProductOptions
    {
        public int? ProductId { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
