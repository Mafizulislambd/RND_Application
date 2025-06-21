using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCSharp
{
    public class ChainingConstractor
    {
        readonly string Name;
        readonly int Age;
        readonly int Balance;
        public ChainingConstractor()
        {
            Console.WriteLine("Default Constractor" );
        }
        public ChainingConstractor(string name,int age):this() 
        {
            Name = name;
            Age = age;
            Console.WriteLine("Parameterized Constractor 2nd: " + name);
        }
        public ChainingConstractor(string name,int age,int balance):this(name, age) 
        {
            Balance = balance;
            Console.WriteLine($"Parameterized Constractor 3rd :{balance}");
        }
        public double Volume()
        {
            return (Age * Balance);
        }
    }
}
