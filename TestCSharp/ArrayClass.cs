using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class ArrayClass
    {
        public static void ArrayExampley()
        {
            int[] intArray;
            intArray=new int[5];
            intArray[0] = 10;
            intArray[1] = 20;  
            intArray[2] = 30;
            intArray[3] = 40;
            intArray[4] = 50;
            Console.Write("For Loop:");
            for (int i = 0; i < intArray.Length; i++) {
            Console.Write( " " + intArray[i]);

            }
            Console.WriteLine("");
            Console.Write("For Each Loop");
            foreach (int i in intArray) {
                Console.Write(" " + i);
            }
            Console.WriteLine("");
            Console.Write("while loop :");
            int j = 0;
            while (j < intArray.Length) {
                Console.Write(" "+ intArray[j]);
                j++;
            }
            Console.WriteLine("");
            Console.Write("Do-while loop :");

            int k = 0;
            do
            {
                Console.Write(" " + intArray[k]);
                k++;
            }
            while (k < intArray.Length);
            Console.WriteLine(" ");
            // declares a 1D Array of string.
            string[] weekDays;

            // allocating memory for days.
            weekDays = new string[] { "Sun", "Mon", "Tue", "Wed",
                             "Thu", "Fri", "Sat" };

            // Displaying Elements of array
            foreach (string day in weekDays)
                Console.Write(day + " ");
            Console.WriteLine("");

            int[,,] arr = new int[2, 2, 3] { { { 1, 2, 3 },
                                            { 4, 5, 6 } },
                                            { { 7, 8, 9 },
                                            { 10, 11, 12 } } };

            // Checking elements at particular index
            Console.WriteLine("arr[1][0][1] : "
                            + arr[1, 0, 1]);

            Console.WriteLine("arr[1][1][2] : "
                            + arr[1, 1, 2]);


            Console.WriteLine(" ");
            // Declaring Jagged Array
            int[][] arrs = { new int[] { 1, 3, 5, 7, 9 },
                        new int[] { 2, 4, 6, 8 } };

            Console.WriteLine("Arrays :");

            // Display the array elements:
            for (int y = 0; y < arr.Length; y++)
            {
                System.Console.Write("Elements[" + y + "] Array: ");

                // Printing the elements of array
                //for (int u = 0; u < arrs[u].Length; u++)
                //{
                //    Console.Write(arrs[y][u] + " ");
                //}

                Console.WriteLine(" ");
            }
            Console.WriteLine("Jugged Arrays.............");
            int[][] jaggedArray = new int[3][];

            // Initialization
            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };

            // Iterating the elements
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Row " + i + ": ");
                foreach (int num in jaggedArray[i])
                    Console.Write(num + " ");

                Console.WriteLine();
            }
           // Console.WriteLine("// Accessing and Modifying Elements");
            // Accessing and Modifying Elements
            // Accessing and Modifying Elements
        }
        public static void juggedArray() {

            // Declaration of a jagged array with 3 rows
            //int[][] arr = new int[3][];

            //// Initializing each row of the jagged array

            //// First row
            //arr[0] = new int[] { 1, 2, 3, 4 };

            //// Second row
            //arr[1] = new int[] { 4, 5, 6 };

            //// Third row (only two elements)
            //arr[2] = new int[] { 7, 8 };

            //// Accessing the third element in
            //// the second row
            //int value = arr[1][2];

            //// Modifying the second element in
            //// the first row (from 2 to 10)
            //arr[0][1] = 10;

            //// Outputting the modified value
            //Console.WriteLine(arr[0][1]);

            //// Outputting the accessed value 
            //// for verification
            //Console.WriteLine("Accessed value: " + value);
            // Declaration and Initialization
            // with Multidimensional Array
            int[][,] arr = new int[2][,] {
            new int[, ] { { 1, 3 }, { 5, 7 } },
            new int[, ] { { 0, 2 }, { 4, 6 }, { 8, 10 } }
                };

            // Display the array elements:
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].GetLength(0); j++)
                {
                    for (int k = 0; k < arr[i].GetLength(1); k++)
                    {
                        Console.Write("arr[" + i + "][" + j
                                      + ", " + k + "] => "
                                      + arr[i][j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
    }
}
