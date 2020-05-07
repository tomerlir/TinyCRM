using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalGross { get; private set; }
        public DateTime Created { get; private set; }
        public bool IsActive { get; set; }

        //Constructor
        public Customer()
        {
        }
    }
}
