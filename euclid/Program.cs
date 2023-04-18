using System;

namespace algorithm.Euclid
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter two numbers:");
            var firstOne = Convert.ToInt32(Console.ReadLine());
            var secondOne = Convert.ToInt32(Console.ReadLine());
            var result = gcd(firstOne, secondOne);
            Console.WriteLine($"GCD of {firstOne} and {secondOne} is {result}.");
        }
        private static int gcd(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            return gcd(b % a, a);
        }
    }

}
