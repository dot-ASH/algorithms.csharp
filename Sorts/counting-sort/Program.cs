using System;

namespace algorithm.Sorts.CountingSort
{
    class Program
    {
        public static void Main()
        {
            int size;
            Console.Write("How many numbers should be in your array? ");
            size = Convert.ToInt32(Console.ReadLine());
            var unsorted = new int[size];

            Console.WriteLine("The numbers? ");
            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted[i] = Convert.ToInt32(Console.ReadLine());
            }

            var unsortedArray = string.Join(",", unsorted);
            Console.WriteLine($"Unsorted Numbers: {unsortedArray}");

            countingSort(unsorted);

            if (isSorted(unsorted))
            {
                var sortedArray = string.Join(",", unsorted);
                Console.WriteLine($"Sorted Numbers: {sortedArray}");
            }
            else System.Console.WriteLine(isSorted(unsorted));
        }

        private static void countingSort(int[] array)
        {
            var max = GetMaxVal(array);
            var occurrences = new int[max + 1];
            for (int i = 0; i < max + 1; i++)
            {
                occurrences[i] = 0;
            }
            for (int i = 0; i < array.Length; i++)
            {
                occurrences[array[i]]++;
            }

            for (int i = 0, j = 0; i <= max; i++)
            {
                while (occurrences[i] > 0)
                {
                    array[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }
        }

        public static int GetMaxVal(int[] array)
        {
            var maxVal = array[0];

            for (int i = 1; i < array.Length; i++)
                if (array[i] > maxVal)
                    maxVal = array[i];

            return maxVal;
        }

        private static bool isSorted(int[] array)
        {
            var prev = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (prev > array[i])
                {
                    return false;
                }
                prev = array[i];
            }
            return true;

        }
    }
}
