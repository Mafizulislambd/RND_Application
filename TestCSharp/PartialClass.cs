using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{

    public partial class PartialClass1
    {
        private string Author_name;
        private int Total_articles;

        public PartialClass1(string a, int t)
        {
            this.Author_name = a;
            this.Total_articles = t;
        }
        //method 1
        //public void M1()
        //{
        //    Console.WriteLine("Partial Class M1");
        //}
    }
    public partial class PartialClass1
    {
        //method 2
        //public void M2()
        //{
        //    Console.WriteLine("Partial Class M2");
        //}
        ////method 3
        //public void M3()
        //{
        //    Console.WriteLine("Partial Class M3");
        //}
        public void Display()
        {
            Console.WriteLine("Author's name is : " + Author_name);
            Console.WriteLine("Total number articles is : " + Total_articles);
        }
    }
    public class PartialClass
    {
        private string Author_name;
        private int Total_articles;

        public PartialClass(string a, int t)
        {
            this.Author_name = a;
            this.Total_articles = t;
        }

        public void Display()
        {
            Console.WriteLine("Author's name is : " + Author_name);
            Console.WriteLine("Total number articles is : " + Total_articles);
        }
    }
}
