using System;
using TinyCrm;

namespace TinyCRM.Options
{
    public class UpdateProductOptions
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
