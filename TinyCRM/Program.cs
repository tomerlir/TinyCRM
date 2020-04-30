using System;

namespace TinyCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Product();
            try
            {
                p.ReadFile();
            }
            catch
            {
                Console.WriteLine("There was an error reading your file");
                return;
            }
        }
    }
}
