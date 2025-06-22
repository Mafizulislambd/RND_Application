using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class VirtualMethod
    {
        public virtual void Move()
        {
            Console.WriteLine("Animal is moving.");
        }

        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
        public virtual void show() { Console.WriteLine("Base class"); }
    }
   public class Dogy : VirtualMethod
    {

        // Overriding the Move method from the base class
        public override void Move()
        {
            Console.WriteLine("Dog is running.");
        }

        public void Bark()
        {
            Console.WriteLine("Dog is barking.");
        }
        public void Eat()
        {
            Console.WriteLine("Test");
        }
         public override void show()
        {
            base.show();
            Console.WriteLine("Derived class");
        }
    }
}
