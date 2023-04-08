using System;

namespace algorithm.Sorts.HeapSort
{
    class Program
    {
        public static void Main()
        {
            Console.Write("How many numbers should be in your array? ");
            int size = Convert.ToInt32(Console.ReadLine());
            var unsorted = new int[size];

            Console.WriteLine("The numbers? ");
            for (int i = 0; i < unsorted.Length; i++)
            {
                unsorted[i] = Convert.ToInt32(Console.ReadLine());
            }

            var unsortedArray = string.Join(",", unsorted);
            Console.WriteLine($"Unsorted Numbers: {unsortedArray}");

            heapSort(unsorted);

            if (isSorted(unsorted))
            {
                var sortedArray = string.Join(",", unsorted);
                Console.WriteLine($"Sorted Numbers: {sortedArray}");
            }
            else System.Console.WriteLine(isSorted(unsorted));
        }

        private static void heapSort(int[] array)
        {
            if (array.Length <= 1) return;
            for (int i = array.Length / 2 - 1; i >= 0; i--)
                heapify(array, array.Length, i);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;
                heapify(array, i, 0);
            }
        }

        public static void heapify(int[] array, int size ,int index)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                heapify(array, size, largestIndex);
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
