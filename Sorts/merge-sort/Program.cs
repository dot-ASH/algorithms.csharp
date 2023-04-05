using System;

namespace algorithm.Sorts.MergeSort
{
    class Program
    {
        public static void Main()
        {
            int size;
            Console.Write("How many numbers should be in your array? ");
            size = Convert.ToInt32(Console.ReadLine());
            var unsorted = new int[size];
            var temp = new int[size];
            Console.WriteLine("The numbers? ");
            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted[i] = Convert.ToInt32(Console.ReadLine());
            }

            var unsortedArray = string.Join(",", unsorted);
            Console.WriteLine($"Unsorted Numbers: {unsortedArray}");

            Array.Copy(unsorted, temp, unsorted.Length);
            mergeSort(unsorted, temp, 0, unsorted.Length - 1);

            if (isSorted(unsorted))
            {
                var sortedArray = string.Join(",", unsorted);
                Console.WriteLine($"Sorted Numbers: {sortedArray}");
            }
        }



        private static void mergeSort(int[] array, int[] temp, int leftIndex, int rightIndex)
        {
            if (rightIndex <= leftIndex) return;
            int midIndex = ((leftIndex + rightIndex) / 2);
            mergeSort(array, temp, leftIndex, midIndex);
            mergeSort(array, temp, midIndex + 1, rightIndex);
            merge(array, temp, leftIndex, midIndex, rightIndex);
        }

        private static void merge(int[] array, int[] temp, int leftIndex, int midIndex, int rightIndex)
        {
            int k = leftIndex, i = leftIndex, j = midIndex + 1;

            while (i <= midIndex && j <= rightIndex)
            {
                if (array[i] <= array[j])
                {
                    temp[k] = array[i];
                    k++; i++;
                }
                else
                {
                    temp[k] = array[j];
                    k++; j++;
                }
            }

            while (i <= midIndex)
            {
                temp[k] = array[i];
                k++; i++;
            }

            for (i = leftIndex; i <= rightIndex; i++)
            {
                array[i] = temp[i];
            }
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
