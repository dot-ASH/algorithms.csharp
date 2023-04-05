using System;

namespace algorithm.quickSort
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

        public static void quickSort(int[] unsorted, int leftIndex, int rightIndex)
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
                while (unsorted[leftPointer] <= unsorted[pivotIndex] && leftPointer < rightPointer)
                {
                    leftPointer++;
                }

                while (unsorted[rightPointer] >= unsorted[pivotIndex] && leftPointer < rightPointer)
                {
                    rightPointer--;
                }
                swap(unsorted, leftPointer, rightPointer);
            }

            swap(unsorted, leftPointer, pivotIndex);
            quickSort(unsorted, leftIndex, leftPointer - 1);
            quickSort(unsorted, leftPointer + 1, rightIndex);

        }

        private static void swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
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
    }

}
