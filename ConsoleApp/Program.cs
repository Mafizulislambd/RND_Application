// See https://aka.ms/new-console-template for more information
using System;
Console.WriteLine("Hello, World!");
//for (int j = 1; j <= 115; j = j + 10)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", j);
//}
//int i = 1;
//while (i <= 1000015)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", i);
//    if (i + 1000 > 1000015)
//        i = 1000015; // Force last iteration to 1000015
//    else
//        i += 1000;
//}
//int j = 0;
//while (j <= 115)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", j);
//    if (j + 10 > 115) // If next step would skip 115
//        j = 115;  // Jump directly to 115
//    else
//        j += 10;
//}
//for (int j = 0; j <= 115; j = j + 10)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", j);

//    if (j + 10 > 115 && j != 115) // If the next step exceeds 115
//    {
//        j = 115 - 10; // Adjust before the next iteration
//    }
//}
for (int j = 0; j <= 115; j = j + 10)
{
    Console.WriteLine("C# For Loop: Iteration {0}", j);
}
