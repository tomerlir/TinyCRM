using System.Collections.Generic;

namespace TinyCRM
{
    class ItemEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            //Products are equal if their id's are equal
            return x.ProductId == y.ProductId;
        }

        public int GetHashCode(Product p)
        {
            return p.ProductId.GetHashCode();
        }
    }
}

