using System;
namespace algorithm.Kadane
{
    class Program
    {
        public static void Main()
        {
            int size;
            Console.Write("How many numbers should be in your array? ");
            size = Convert.ToInt32(Console.ReadLine());
            var array = new int[size];

            Console.WriteLine("The numbers? ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            var output = string.Join(",", array);
            System.Console.WriteLine($"The array:-\n[ {output} ]");
            int maxSum = Kadane(array);
            Console.WriteLine($"Maximum contiguous sum:- {maxSum}");
        }
        static int Kadane(int[] arr)
        {
            int maxSum = arr[0];
            int currSum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                currSum = Math.Max(arr[i], currSum + arr[i]);
                maxSum = Math.Max(maxSum, currSum);
            }
            return maxSum;
        }
    }
}