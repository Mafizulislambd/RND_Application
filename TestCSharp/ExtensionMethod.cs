using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class ExtensionMethod
    { 
        //method 1
        public void M1()
        {
            Console.WriteLine("Extension Method M1");
        }
        //method 2
        public void M2()
        {
            Console.WriteLine("Extension Method M2");
        }
        //method 3
        public void M3()
        {
            Console.WriteLine("Extension Method M3");
        }
    }
    public static class NewExtensionMethods
    {
        // Extension method for the ExtensionMethod class
        public static void M4(this ExtensionMethod ext)
        {
            Console.WriteLine("Extension Method M4");
        }
        // Another extension method for the ExtensionMethod class
        public static void M5(this ExtensionMethod ext,string str)
        {
            Console.WriteLine($"Extension Method M5{str}");
        }
    }
}
