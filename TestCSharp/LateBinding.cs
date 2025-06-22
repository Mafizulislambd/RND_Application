using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class LateBinding
    {
        dynamic obj = 4;
        dynamic obj1 = 5.678;
        public void DataType()
        {
            // Display the type of obj
            Console.WriteLine("Type of obj: " + obj.GetType());
            // Display the type of obj1
            Console.WriteLine("Type of obj1: " + obj1.GetType());
            // Display the value of obj
            Console.WriteLine("Value of obj: " + obj);
            // Display the value of obj1
            Console.WriteLine("Value of obj1: " + obj1);
        }
    }
}
