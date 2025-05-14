using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class ArrayShort
    {
        public static void ArrayShorts()
        {
            Console.WriteLine(" ");
            string[] arr = new string[5] { "A", "D", "X", "G", "M" };

            // Display original array
            Console.WriteLine("Original Array:");
            foreach (string g in arr)
            {
                Console.WriteLine(g);
            }

            Console.WriteLine("\nAfter Sort:");

            // Sorting the array
            Array.Sort(arr);

            // Display sorted array
            foreach (string g in arr)
            {
                Console.WriteLine(g);
            }

            Console.WriteLine("\nBinary Search for 'B':");

            // Binary Search for "B"
            int index = Array.BinarySearch(arr, "B");
            sortT(arr, index);

            Console.WriteLine("\nBinary Search for 'F':");

            // Binary Search for "F"
            index = Array.BinarySearch(arr, "F");
            sortT(arr, index);
        }
        public static void sortT<T>(T[] arr, int index)
        {
            // If the index is negative, it represents the 
            // bitwise complement of the next larger element
            if (index < 0)
            {

                // Convert to the actual index of 
                // the next larger element
                index = ~index;

                if (index == 0)
                    Console.WriteLine("Element would be inserted at the beginning of the array.");
                else
                    Console.WriteLine($"Element would be inserted between {arr[index - 1]} and {arr[index]}.");

                if (index == arr.Length)
                    Console.WriteLine("Element would be inserted at the end of the array.");
            }
            else
            {
                Console.WriteLine($"Element 'B' or 'F' found at index {index}.");
            }
        }
    }
}
