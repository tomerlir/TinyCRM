using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRM
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string PhoneNumber { get; set; }
        public decimal TotalGross { get; private set; }
        public DateTime Created { get; private set; }
        public bool IsActive { get; set; }
        public List<Customer> CustomerList { get; private set; } = new List<Customer>();
        public List<Product> ListOfOrders { get; set; } = new List<Product>();

        //Constructor
        public Customer()
        {
        }

        //Check if Customer has a valid afm
        public bool IsValidAfm(string afm)
        {
            if (!string.IsNullOrWhiteSpace(afm))
            {
                afm = afm.Trim();
                if (int.TryParse(afm, out int numericafm))
                {
                    //Console.WriteLine($"It is numeric {numericafm}");
                    if (afm.Length == 9)
                    {
                       // Console.WriteLine("Success");
                        VatNumber = afm;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Please insert again");
                        return false;
                    }
                }
            }
            Console.WriteLine("Not a numeric input");
            return false;
        }

        //Check if Customer is an adult
        public bool IsAdult(int age)
        {
            return age >= 18 && age <= 105;
        }

        //Check if Customer has a valid email
        public bool IsValidEmail(string emailInput)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(emailInput);
                // Check: Console.WriteLine($"{emailInput} is a valid email address");
                return email.Address == emailInput;
            }
            catch
            {
                Console.WriteLine($"{emailInput} is an invalid email address");
                return false;
            }
        }

        public void AddCustomer(string vatNumber, string customerId, string firstName, string lastName, int age, string emailAddress, string phoneNumber, decimal totalGross, bool isActive)
        {
            Customer newCustomer = new Customer();
            newCustomer.VatNumber = vatNumber;
            if (!IsValidAfm(vatNumber) || !IsValidEmail(emailAddress))
            {
                throw new Exception("Invalid Vat Number or email");
            }
            newCustomer.Created = DateTime.Now;
            newCustomer.CustomerId = customerId;
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            newCustomer.Age = age;
            newCustomer.Email = emailAddress;
            newCustomer.PhoneNumber = phoneNumber;
            newCustomer.TotalGross = totalGross;
            newCustomer.IsActive = isActive;
            CustomerList.Add(newCustomer);
        }

        public void PrintCustomers()
        {
            foreach(Customer c in CustomerList)
            {
                Console.WriteLine($"ID: {c.CustomerId}, VAT: {c.VatNumber}, Name: {c.FirstName}");
            }
        }

        public void AddProductToCustomer(Customer customer, Product product)
        {
            customer.ListOfOrders.Add(product);
            /*Test if Product is added correctly to Customer (SUCCESS)
            Console.WriteLine($"Customer {customer.FirstName} has ordered: {product.Name}");
            */
        }

        public Customer GetCustomerById(string customerId)
        {
            return CustomerList.FirstOrDefault(Customer => Customer.CustomerId.Equals(customerId));
        }

        public decimal ReturnTotalGross(Customer customer)
        {
            return customer.TotalGross = customer.ListOfOrders.Sum(Product => Product.Price);
        }

    }
}
