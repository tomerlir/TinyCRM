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
        public int? CustomerId { get; set; }
    }
}
