using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class DelegateExample
    {
        public delegate void AddSum(int a, int b);
        public delegate void AddSum2(int a, int b);

        public void Add(int a, int b)
        {
            Console.WriteLine("(100 - 60) = {0}", a + b);
        }
        public void Add2(int a, int b)
        {
            Console.WriteLine("(100 - 60) = {0}", a - b);
        }
    }
    class rectangle
    {

        // declaring delegate
        public delegate void rectDelegate(double height,
                                          double width);

        // "area" method
        public void area(double height, double width)
        {
            Console.WriteLine("Area is: {0}", (width * height));
        }

        // "perimeter" method
        public void perimeter(double height, double width)
        {
            Console.WriteLine("Perimeter is: {0} ", 2 * (width + height));
        }
        public static void PrintMessage()
        {
            Console.WriteLine("Hello, Geek");
        }
        public static void SubtractNumbers(int p, int q)
        {
            Console.WriteLine(p - q);
        }
    }
}
