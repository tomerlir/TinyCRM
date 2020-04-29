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
        private string Name { get; set; }
        private decimal Price { get; set; }

        //Constructor
        public Product()
        {

        }
        /*        HOMEWORK 29/04/2020              */
        //1. Parse the file's contents and create a list where all products can be found
        //2. Randomize Price and add to Product
        //3. Ensure that only unique codes are found in the list of products. No product codes should be found twice.

        public void ReadFile()
        {
            string filePath = @"/Users/tomerliran/Projects/TinyCRM/TinyCRM/ProductsList.txt"; //File directory
            Random rand = new Random(); //Random number generator

            List<Product> productList = new List<Product>(); //Create new list ready to be populated
            List<string> lines = File.ReadAllLines(filePath).ToList(); //Read file and put into a list of string 

            foreach (var line in lines)
            {
                string[] entries = line.Split(';'); //For each line split it apart at the semicolon
                Product newProduct = new Product(); //Create a new product entry based upon the split apart entries (seen below)

                newProduct.ProductId = entries[0];
                newProduct.Name = entries[1];
                newProduct.Description = entries[2];
                newProduct.Price = new decimal(Math.Round(rand.NextDouble() * 40, 3));
                productList.Add(newProduct); //Fill in Product based on added entries

            }

            //System.Linq extension method. Remove duplicates considering only the ProductId of each object

            /* Use for test: var result = */
            productList.Distinct(new ItemEqualityComparer());

            /* Check if removing duplicate (SUCCESS)
            int i = 0;
            foreach(var productId in result)
            {
                Console.WriteLine($"{i}. DISTINCT Products = {productId.ProductId} And {productId.Name}");
                i++;
            }
            */
            /*  Check if saving properly (SUCCESS)
            int j = 0;
            foreach (var product in productList)
            {
                Console.WriteLine($"Line: {j} {product.ProductId} ; {product.Name} ; {product.Description} ; {product.Price}");
                j++;
            }
            */
        }
    }
}