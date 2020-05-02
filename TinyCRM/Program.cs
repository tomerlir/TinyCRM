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
                var c = new Customer();
                var p = new Product();
                var o = new Order();

                p.ReadFile();

                c.AddCustomer("123456789", "1", "Tomer", "Liran", 25, "tl@gmail.com", "6931246352", 0.00M, true);
                c.AddCustomer("925927530", "2", "Danai", "Papa", 22, "gl@gmail.com", "6988032549", 0.00M, true);

                var testProductList1 = new List<Product>();
                var testProductList2 = new List<Product>();
                List<Product> set = new List<Product>();

                var testid = "1";
                var testid2 = "2";
                var testAddress1 = "Chalandri";
                var testAddress2 = "Pallini";
                for (int i = 0; i < 10; i++)
                {
                    var item = p.GetRandomProduct();
                    var item2 = p.GetRandomProduct();
                    testProductList1.Add(item);
                    testProductList2.Add(item2);
                    c.AddProductToCustomer(c.GetCustomerById(testid), item);
                    c.AddProductToCustomer(c.GetCustomerById(testid2), item2);
                 }

                o.addOrder(c.GetCustomerById(testid),testProductList1, testid, testAddress1, c.ReturnTotalGross(c.GetCustomerById(testid)));

                o.addOrder(c.GetCustomerById(testid2), testProductList2, testid2, testAddress2, c.ReturnTotalGross(c.GetCustomerById(testid2)));

                Console.WriteLine("Youre highest paying customer is:");
                if (c.GetCustomerById(testid).TotalGross > c.GetCustomerById(testid2).TotalGross)
                {
                    Console.WriteLine(c.GetCustomerById(testid).FirstName);
                } else if (c.GetCustomerById(testid).TotalGross < c.GetCustomerById(testid2).TotalGross)
                {
                    Console.WriteLine(c.GetCustomerById(testid2).FirstName);
                }
                else
                {
                    Console.WriteLine("We cant tell who's spent more!");
                }

                set.AddRange(testProductList1);
                set.AddRange(testProductList2);

                var query = set.GroupBy(Product => Product)
                                .Where(ProductId => ProductId.Count() > 1)
                                .Select(ProductId => ProductId.Key)
                                .ToList();

                if(query.Count() > 1)
                {
                    foreach (var s in query)
                    {
                        Console.WriteLine($"Your Highest Selling Products were: {s.ProductId}, {s.Name}, with {query.Count()} sales");
                    }
                }
                else
                {
                    Console.WriteLine("No single product stood out in terms of sales");
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
