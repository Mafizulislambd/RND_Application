using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class AbstractClassType
    {
    }
    public abstract class AbstractClass
    {
        public abstract void Display();
        public abstract int Calculate(int a, int b);
        public void Show()
        {
            Console.WriteLine("This is a concrete method in an abstract class.");
        }
    }
    public class ConcreteClass : AbstractClass
    {
        public override void Display()
        {
            Console.WriteLine("Display method implemented in ConcreteClass.");
        }
        public override int Calculate(int a, int b)
        {
            return a + b; // Example implementation
        }
    }

    public interface IInterface 
    {
        void InterfaceMethod();
        int InterfaceProperty { get; set; }
        private void PrivateMethod()
        {
            Console.WriteLine("This is a private method in an interface.");
        }
        //public IInterface()
        //{
        //    Console.WriteLine( "This is a constructor in an interface, which is not allowed in C#.");
        //}
        protected void ProtectedMethod()
        {
            Console.WriteLine("This is a protected method in an interface.");
        }

        CancellationTokenRegistration Register(Action callback, CancellationToken cancellationToken)
        {
            // This method is not typically used in interfaces, but can be defined for demonstration.
            Console.WriteLine("Registering a callback with a cancellation token.");
            return new CancellationTokenRegistration();
        }
    }

    public class InterfaceImplementation : IInterface
    {
        public void InterfaceMethod()
        {
            Console.WriteLine("Interface method implemented.");
        }
        public int InterfaceProperty { get; set; } = 42; // Example property implementation
    }


}
