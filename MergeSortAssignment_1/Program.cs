using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortAssignment_1
{
    internal class Program
    {
        // Main method
        static void Main(string[] args)
        {
            // Create an array of integers to be sorted
            int[] arr = { 15, 2, 17, 9, 34, 12, 6, 48 };

            // Print the original array
            Console.WriteLine("Original array:");
            PrintArray(arr);

            // Call the MergeSort method with the array
            MergeSortArray(arr);

            // Print the sorted array
            Console.WriteLine("\n Sorted Array:");
            PrintArray(arr);
        }
        // MergeSort method
        static void MergeSortArray(int[] arr)
        {
            //Merge Sort is a recursive algorithm that divides an array into smaller subarrays, sorts each subarray,
            //and then merges the sorted subarrays back together to form the final sorted array.
            //The time complexity of Merge Sort is O (n log n) for all cases (best, average, and worst), where n is the number of elements in the array.
            //This means that Merge Sort takes approximately n log n steps to sort an array of size n.
            //Merge Sort is more efficient than simpler sorting algorithms like Bubble Sort because it does not compare every pair of elements in the array,
            //but rather uses a divide and conquer strategy to reduce the number of comparisons.
            int arrayLength = arr.Length;
            // If the array has only one element(or has 1 or 0 element),
            // it is already sorted. Return the array.
            if (arr.Length <= 1) //base case
            {
                Console.WriteLine("Base case reached: Array is already sorted or empty.");
                return;
            }
            // Lets Calculate the middle index of the array
            // by dividing into two halves, left half and right half
            int midIndex = arr.Length / 2;
            //Lets declare an array of integers called leftSubarray with the size equal to midIndex,
            //which is the middle index of the original array.
            int[] leftSubarray = new int[midIndex];
            //Lets declare another array of integers called rightSubarray with
            //the size equal to the difference between the length of the original array and midIndex.
            int[] rightSubarray = new int[arr.Length - midIndex];
            //Copy the elements from the original array, starting from index 0, to the leftSubarray,
            //starting from index 0, up to midIndex elements.
            Array.Copy(arr, 0, leftSubarray, 0, midIndex);
            //Copy the elements from the original array, starting from midIndex, to the rightSubarray,
            //starting from index 0, up to the remaining elements.
            Array.Copy(arr, midIndex, rightSubarray, 0, arr.Length - midIndex);

            // Display the contents of left and right subarrays
            Console.WriteLine("Left Subarray:");
            PrintArray(leftSubarray);
            Console.WriteLine("Right Subarray:");
            PrintArray(rightSubarray);

            // Call MergeSort on the left half and
            // store the result in a new array called leftSorted
            Console.WriteLine("Sorting left subarray:");
            MergeSortArray(leftSubarray);
            // Call MergeSort on the right half and
            // store the result in a new array called rightSorted
            Console.WriteLine("Sorting right subarray:");
            MergeSortArray(rightSubarray);
            // Call Merge on leftSorted and rightSorted and
            // store the result in a new array called sorted
            Console.WriteLine("Merging sorted subarray:");
            Merge(leftSubarray, rightSubarray, arr);
        }
        // Merge function
        static void Merge(int[] leftSubarray, int[] rightSubarray, int[] arr)
        {
            int leftLength = leftSubarray.Length;
            int rightLength = rightSubarray.Length;

            // Lets create a new array called merged with the same size as the sum of the two subarrays
            // those are left subarray and right subarray
            int[] merged = new int[leftSubarray.Length + rightSubarray.Length];
            // Lets initialize the three indices: i for the left subarray,
            // j for the right subarray, and k for the merged array
            int i = 0, j = 0, k = 0;
            // While i and j are both less than the sizes of their respective subarrays,

            while (i < leftSubarray.Length && j < rightSubarray.Length)
            {
                // compare the elements at left[i] and right[j].
                if (leftSubarray[i] <= rightSubarray[j])
                {
                    //  If left[i] is smaller or equal to right[j]
                    // copy it to merged[k] and increment i and k.
                    merged[k] = leftSubarray[i];
                    i++;
                }
                else
                {
                    // Otherwise, copy right[j] to merged[k] and increment j and k.
                    merged[k] = rightSubarray[j];
                    j++;
                }
                k++;
            }

            while (i < leftSubarray.Length)
            {
                // If i reaches the end of the left subarray,
                // copy the remaining elements of the right subarray to merged.
                merged[k] = leftSubarray[i];
                i++;
                k++;
            }
            while (j < rightSubarray.Length)
            {// If j reaches the end of the right subarray,
             // copy the remaining elements of the left subarray to merged.

                merged[k] = rightSubarray[j];
                j++;
                k++;
            }
            // Copy the merged array to the original array
            Array.Copy(merged, 0, arr, 0, merged.Length);
        }

        // PrintArray method
        static void PrintArray(int[] arr)
        {
            // Loop through the array and print each element
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}

