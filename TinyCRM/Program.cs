using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();

            /*Insert
            var customer = new Customer()
            {
                FirstName = "Tomer",
                LastName = "Liran",
                Email = "tliran@dotnetacademy.gr",
                VatNumber = "123456780"
            };*/

            var co = new CustomerOptions()
            {
                FirstName = "Tomer",
                LastName = "Liran",
                VatNumber = "123456780",
                CustomerId = 4,
                CreateFrom = new DateTime(5 / 3 / 2020),
                CreatedTo = new DateTime(5 / 7 / 2020)
            };

            //Careful when searching to make sure all info in CustomerOptions is correctly inputted or else will get an error
            var c = co.SearchCustomers(co, tinyCrmDbContext);
            Console.WriteLine($"The customer you searched for is: ID: {c.CustomerId}," +
                $" Name: {c.FirstName}, " +
                $"Surname: {c.LastName}, " +
                $"Vat Number {c.VatNumber}");
        }
    }
}
