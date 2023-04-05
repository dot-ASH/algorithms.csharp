using System;

namespace algorithm.Sorts.SelectionSort
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

            selectionSort(unsorted);

            if (isSorted(unsorted))
            {
                var sortedArray = string.Join(",", unsorted);
                Console.WriteLine($"Sorted Numbers: {sortedArray}");
            }
            else System.Console.WriteLine(isSorted(unsorted));
        }

        private static void selectionSort(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                swap(array, min, i);
            }
        }

        private static void swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
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