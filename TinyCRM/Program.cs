using System;

namespace TinyCRM
{
    class Program
    {
        /* TinyCRM
         * AFM length = 9, only numeric chars
         * IsValidAfm(afm)
         */

        static void Main(string[] args)
        {
            /* Check if IsValidAfm is working
             IsValidAfm("12412");
             IsValidAfm("135017284");
             IsValidAfm("Hello mate");
             */

            /*Check if IsAdult is working
             IsAdult(12);
             IsAdult(19);
             */

            /*Check if IsValidEmail is working
            IsValidEmail("hello@gmail.com");
            IsValidEmail("hello@@@gmail.com");
            IsValidEmail("124asd");
            IsValidEmail("   ");
            */
        }

        public static bool IsValidAfm(string afm)
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

        public static bool IsAdult(int age)
        {
            return age >= 18 && age <= 105;
        }

        public static bool IsValidEmail(string emailInput)
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
