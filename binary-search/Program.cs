using System;

namespace algorithm.BinarySearch
{
    class Program
    {
        public static void Main()
        {
            int size, searchFor;
            Console.Write("How many numbers should be in your array? ");
            size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("The numbers? ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("What do you want to search? ");
            searchFor = Convert.ToInt32(Console.ReadLine());
            Array.Sort(array);
            
            int pos = binarySearch(array, searchFor);
            if (pos == -1)
            {
                Console.WriteLine("The number couldn't be found");
            }
            else
            {
                var sortedArray = string.Join("," , array);
                Console.WriteLine($"Sorted array: {sortedArray}");
                Console.WriteLine($"The number is at position: {pos + 1}");
            }
        }
        public static int binarySearch(int[] array, int searchFor)
        {
            int leftIndex = 0;
            int rightIndex = (array.Length - 1);

            while (leftIndex <= rightIndex)
            {
                int midIndex = ((rightIndex + leftIndex) / 2);
                if (searchFor == array[midIndex])
                {
                    return midIndex;
                }
                else if (searchFor < array[midIndex])
                {
                    rightIndex = midIndex - 1;
                }
                else
                {
                    leftIndex = midIndex + 1;
                }
            }
            return -1;
        }

    }



}
