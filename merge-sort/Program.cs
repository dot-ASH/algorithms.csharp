using System;

namespace algorithm.mergeSort
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

        private static bool isSorted(int[] unsorted)
        {
            var prev = unsorted[0];
            for (int i = 1; i < unsorted.Length; i++)
            {
                if (prev > unsorted[i])
                {
                    return false;
                }
                prev = unsorted[i];
            }
            return true;

        }

        public static void mergeSort(int[] unsorted, int[] temp, int leftIndex, int rightIndex)
        {
            if (rightIndex <= leftIndex) return;
            int midIndex = ((leftIndex + rightIndex)/2);
            mergeSort(unsorted, temp, leftIndex, midIndex);
            mergeSort(unsorted, temp, midIndex + 1, rightIndex);
            merge(unsorted, temp, leftIndex, midIndex, rightIndex);
        }

        private static void merge(int[] unsorted, int[] temp, int leftIndex, int midIndex, int rightIndex)
        {
            int k = leftIndex, i = leftIndex, j = midIndex + 1;

            while (i <= midIndex && j <= rightIndex)
            {
                if (unsorted[i] <= unsorted[j])
                {
                    temp[k] = unsorted[i];
                    k++; i++;
                }
                else
                {
                    temp[k] = unsorted[j];
                    k++; j++;
                }
            }

            while (i <= midIndex)
            {
                temp[k] = unsorted[i];
                k++; i++;
            }

            for (i = leftIndex; i <= rightIndex; i++)
            {
                unsorted[i] = temp[i];
            }
        }
    }

}
