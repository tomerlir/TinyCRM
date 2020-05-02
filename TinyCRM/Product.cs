using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCRM
{
    public class Product
    {
        public string ProductId { get; private set; }
        private string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Product> ProductList { get; set; } = new List<Product>(); //Create new list ready to be populated

        //Constructor
        public Product()
        {

        }

        /*        HOMEWORK OF 29/04/2020              */
        //1. Parse the file's contents and create a list where all products can be found
        //2. Randomize Price and add to Product
        //3. Ensure that only unique codes are found in the list of products. No product codes should be found twice.

        public void ReadFile()
        {
            Random rand = new Random(); //Random number generator
            string filePath = @"/Users/tomerliran/Projects/TinyCRM/TinyCRM/ProductsList.txt"; //File directory
            var set = new HashSet<string>(); //HashSet to save ProductId

            var lines = File.ReadAllLines(filePath).ToList(); //Read file and put into a list of string

            foreach (var line in lines)
            {
                string[] entries = line.Split(';'); //Split each line apart at the semicolon
                var newProduct = new Product(); //Create a new product entry based upon the split apart entries (seen below)

                newProduct.ProductId = entries[0];
                newProduct.Name = entries[1];
                newProduct.Description = entries[2];
                newProduct.Price = new decimal(Math.Round(rand.NextDouble() * 40, 3));

                //Nested loop to check HashSet if ProductId already exists there
                for (int k = 0; k < lines.Count; k++)
                {
                    if (!set.Contains(newProduct.ProductId))
                    {
                        ProductList.Add(newProduct);
                        set.Add(newProduct.ProductId);
                    }
                }
            }
        }

        public void PrintProductList()
        {
            foreach (Product product in ProductList)
            {
                Console.WriteLine($"{product.ProductId} ; {product.Name} ; {product.Description} ; {product.Price}");
            }
        }

        public Product GetProductById(string prodId)
        {
            return ProductList.FirstOrDefault(Product => Product.ProductId.Equals(prodId));
        }

        public Product GetRandomProduct()
        {
            var random = new Random();
            return ProductList.OrderBy(Produt => random.NextDouble()).First();
        }
    }
}