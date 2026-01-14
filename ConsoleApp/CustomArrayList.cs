using System.Collections;
using System.Dynamic;
using System.Numerics;
namespace ConsoleApp
{
    public class CustomArrayList
    {
        // Fix 1: Rename the class to avoid conflict with System.Collections.ArrayList
       
            public static void AddElement()
            {
                // Fix 2: Use System.Collections.ArrayList instead of the conflicting class name
               ArrayList al = new ArrayList();
                al.Add("Hello");
                al.Add(123);
                al.Add(45.67);
                Console.WriteLine("Elements in ArrayList:");
                foreach (var item in al)
                {
                    Console.WriteLine(item);
                }
            }
        
    }
    public class GenericList<T>
    {
        public void Add(T item) { }
    }

    public class ExampleClass {
    
    }
    public class Box<T>
    {
        public T Item { get; set; }
        public void AddItem(T item)
        {
            Item = item;
        }
    }

    public class ListItem
    {
        public static T GetFirstItem<T>(List<T> items)
        {
            return items[0];
        }

        // Fix: Move the initialization of 'firstName' to the constructor or a method
        List<string> names = new List<string> { "Hello", "World" };
        string firstName;

        public ListItem()
        {
            

        }
    }
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return Price.CompareTo(other.Price);
        }

        static T Add<T>(T left, T right) where T : INumber<T>
        {
            return left + right;
        }

        int result = Add(5, 10); // Works with integers
        double resultDouble = Add(5.5, 10.2); // Works with doubles

        public void DisplayProduct()
        {
            var products = new[] {
        new { Name = "Laptop", Price = 1200 },
        new { Name = "Tablet", Price = 600 }
             };

            var filteredProducts = from p in products
                                   where p.Price > 1000
                                   select new { p.Name, p.Price };

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
            }
        }
    }

}
