using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{

   public class Animal
    {
        public delegate void petanim(string pet);
        petanim g = delegate (string p)
        {
            Console.WriteLine("My favorite pet is: {0}",
                                                 p);
        };
       // g("dog");

        // Base class
        public virtual void Move()
        {
            Console.WriteLine("Animal is moving.");
        }

        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }

    class Dog : Animal
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
    }
    class baseClass

    {
        public void show() { Console.WriteLine("Base class"); }
    }

    // derived class name 'derived'
    // 'baseClass' inherit here
    class derived : baseClass
    {

        // overriding
        new public void show()
        {
            base.show();
            Console.WriteLine("Derived class");
        }
    }
}
