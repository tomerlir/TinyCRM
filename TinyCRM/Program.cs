using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var random = new Random();
                var c = new Customer();
                var p = new Product();
                var o = new Order();

                p.ReadFile();

                c.AddCustomer("123456789", "1", "Tomer", "Liran", 25, "tl@gmail.com", "6931246352", 0.00M, true);
                c.AddCustomer("925927530", "2", "Danai", "Papa", 22, "gl@gmail.com", "6988032549", 0.00M, true);

                var testProductList = new List<Product>();
                var testid = "1";
                var testid2 = "2";

                var set = new HashSet<string>();
                var counter1 = 0;
                for (int i = 0; i < 10; i++)
                {
                    var item = p.ProductList.OrderBy(Produt => random.NextDouble()).First();
                    testProductList.Add(item);
                    c.AddProductToCustomer(c.GetCustomerById(testid), item);

                    for (int k = 0; k < testProductList.Count; k++)
                    {
                        if (set.Contains(item.ProductId))
                        {
                            counter1++;
                        }

                    }
                    set.Add(item.ProductId);
                }

                decimal total = testProductList.Sum(Product => Product.Price);
                o.addOrder(c.GetCustomerById(testid),testProductList, "1", "Chalandri", total);

                for (int i = 0; i < 10; i++)
                {
                    var item = p.ProductList.OrderBy(Produt => random.NextDouble()).First();
                    testProductList.Add(item);
                    c.AddProductToCustomer(c.GetCustomerById(testid2), item);

                    for (int k = 0; k < testProductList.Count; k++)
                    {
                        if (set.Contains(item.ProductId))
                        {
                            counter1++;
                        }
                    }
                    set.Add(item.ProductId);
                }



                decimal total2 = testProductList.Sum(Product => Product.Price);
                o.addOrder(c.GetCustomerById(testid2), testProductList, "2", "Chalandri", total2);

                Console.WriteLine("Your Customers Have Ordered:");
                o.PrintOrder();
                //
                Console.WriteLine("Youre highest paying customer is:");
                if (total > total2)
                {
                    Console.WriteLine(c.GetCustomerById(testid).FirstName);
                } else if ( total < total2)
                {
                    Console.WriteLine(c.GetCustomerById(testid2).FirstName);
                }
                else
                {
                    Console.WriteLine("We cant tell who's spent more!");
                }
            }
            catch
            {
                Console.WriteLine("There was an error reading your file");
                return;
            }
        }
    }
}
