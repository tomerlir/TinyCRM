using System;
using System.Linq;

namespace TinyCRM
{
    public class CustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public DateTime CreateFrom { get; set; }
        public DateTime CreatedTo { get; set; }
        public int CustomerId { get; set; }

        public CustomerOptions()
        {
        }

        public Customer SearchCustomers(CustomerOptions custo, TinyCrmDbContext tinyCrmDbContext)
        {
            Customer customer = tinyCrmDbContext
                .Set<Customer>()
                .Take(500)
                .Where(c => c.FirstName.Equals(custo.FirstName)
                && c.CustomerId == custo.CustomerId
                && c.LastName.Equals(custo.LastName)
                && c.VatNumber.Equals(custo.VatNumber)
                && c.Created.Date >= custo.CreateFrom.Date && c.Created.Date <= custo.CreatedTo)
                .FirstOrDefault();
            return customer;
        }
    }
}
