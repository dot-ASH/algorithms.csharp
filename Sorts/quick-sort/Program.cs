using System;

namespace algorithm.Sorts.QuickSort
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

            quickSort(unsorted, 0, (unsorted.Length - 1));

            if (isSorted(unsorted))
            {
                var sortedArray = string.Join(",", unsorted);
                Console.WriteLine($"Sorted Numbers: {sortedArray}");
            }
            else System.Console.WriteLine(isSorted(unsorted));
        }

        private static void quickSort(int[] array, int leftIndex, int rightIndex)
        {
            var pivotIndex = rightIndex;
            var leftPointer = leftIndex;
            var rightPointer = rightIndex;

            if (leftIndex >= rightIndex)
            {
                return;
            }

            while (leftPointer < rightPointer)
            {
                while (array[leftPointer] <= array[pivotIndex] && leftPointer < rightPointer)
                {
                    leftPointer++;
                }

                while (array[rightPointer] >= array[pivotIndex] && leftPointer < rightPointer)
                {
                    rightPointer--;
                }
                swap(array, leftPointer, rightPointer);
            }

            swap(array, leftPointer, pivotIndex);
            quickSort(array, leftIndex, leftPointer - 1);
            quickSort(array, leftPointer + 1, rightIndex);

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
