using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public delegate void MyDelegate(string message);

    internal class DelegateClass
    {
        public static void PrintMsg(string message) {

            Console.WriteLine("Delegate called with message: " + message);
        }
     public static void Method1(string msg) => Console.WriteLine("Method1: " + msg);
     public static  void Method2(string msg) => Console.WriteLine("Method2: " + msg);
        public async Task<string> GetDataAsync()
        {
            await Task.Delay(2000); // Simulating a delay (e.g., waiting for a web request)
            return "Data received";
        }


        // Usage:
        //string name = "hello world";
        //Console.WriteLine(name.ToTitleCase()); // Output: Hello World
    }
    public static class StringExtensions
    {
        public static  string ToTitleCase( this string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
    class ResourceHandler
    {
        ~ResourceHandler()
        {
            Console.WriteLine("Finalizer called by GC.");
        }
    }




}
