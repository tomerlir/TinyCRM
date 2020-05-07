using System;
using System.Linq;

namespace TinyCRM
{
    public class ProductOptions
    {
        public int ProductId { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public string ProductCategory { get; set; }

        public ProductOptions()
        {
        }

        public Product SearchProducts(ProductOptions prodo, TinyCrmDbContext tinyCrmDbContext)
        {
            Product product = tinyCrmDbContext
                .Set<Product>()
                .Take(500)
                .Where(p => p.ProductId == prodo.ProductId
                && p.ProductCatergory.Equals(prodo.ProductCategory)
                && p.Price >= prodo.PriceFrom && p.Price <= prodo.PriceTo)
                .FirstOrDefault();
            return product;
        }
    }
}
