using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
  
    sealed class SealedClass
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    public class SealedClassDemo
    {
        public static void Main(string[] args)
        {
            // Getting interface of specified name
            // using GetInterfaces(String) Method
            Type objType2 = typeof(SealedClass);
            Type[] minterface2 = objType2.GetInterfaces();
            // Display the Result
            Console.WriteLine("Interface present in type {0}", objType2);
            for (int i = 0; i < minterface2.Length; i++)
                Console.WriteLine(" {0}", minterface2[i]);
        }
    }
    public class Test:SealedClassDemo
    {
        
    }
}
