using System;
namespace TinyCRM
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string PhoneNumber { get; set; }
        public decimal TotalGross { get; private set; }
        public DateTime Created { get; private set; }
        public bool IsActive { get; set; }

        //Constructor
        public Customer(string vatNumber)
        {
            if (!IsValidAfm(vatNumber))
            {
                throw new Exception("Invalid VatNumber");
            }

            this.VatNumber = vatNumber;
            Created = DateTime.Now;
        }

        //Check if Customer has a valid afm
        public bool IsValidAfm(string afm)
        {
            if (!string.IsNullOrWhiteSpace(afm))
            {
                afm = afm.Trim();
                if (int.TryParse(afm, out int numericafm))
                {
                    Console.WriteLine($"It is numeric {numericafm}");
                    if (afm.Length == 9)
                    {
                        Console.WriteLine("Success");
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
                Console.WriteLine($"{emailInput} is a valid email address");
                return email.Address == emailInput;
            }
            catch
            {
                Console.WriteLine($"{emailInput} is an invalid email address");
                return false;
            }
        }
    }
}
