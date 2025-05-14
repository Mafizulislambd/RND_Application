using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class Geeks
    {
        public int Add(int a, int b)
        {
            int sum = a + b;
            return sum;
        }

        // adding three integer values.
        public int Add(int a, int b, int c)
        {
            int sum = a + b + c;
            return sum;
        }
       

        // adding three double values.
        public static double Add(double a,
                        double b, double c)
        {
            double sum = a + b + c;
            return sum;
        }
        public void Identity(String name, int id)
        {
            Console.WriteLine("Name1 : " + name + ", "
                            + "Id1 : " + id);
        }

        public void Identity(int id, String name)
        {
            Console.WriteLine("Name2 : " + name + ", "
                            + "Id2 : " + id);
        }
        public static void addstr(string s1, string s2, string s3)
        {
            string result = s1 + s2 + s3;
            Console.WriteLine("Final string is: " + result);
        }

       public static void CompareValue(ref string val1)
        {
            // Compare the value 
            if (val1 == "Dog")
            {
                Console.WriteLine("Matched!");
            }

            // Assigning new value 
            val1 = "Cat";
        }
        public static void AddNum(out int num)
        {
            num = 80;
            num += num;
        }
        static public void detail(string ename,
                               int eid,
                               string bgrp = "A+",
                    string dept = "Review-Team")

        {
            Console.WriteLine("Employee name: {0}", ename);
            Console.WriteLine("Employee ID: {0}", eid);
            Console.WriteLine("Blood Group: {0}", bgrp);
            Console.WriteLine("Department: {0}", dept);
        }
        
        // Method which contains dynamic parameter 
        public static void mulval(dynamic val)
        {
            val += val;
            Console.WriteLine(val);
        }
        public static int mulval(params int[] num)
        {
            int res = 1;

            // foreach loop 
            foreach (int j in num)
            {
                res *= j;
                Console.WriteLine(res);
            }
            return res;
        }


        public static void Main(String[] args)
        {
            Geeks ob = new Geeks();

            int sum1 = ob.Add(1, 2);
            Console.WriteLine("add() with two integers");
            Console.WriteLine("sum: " + sum1);

            Console.WriteLine("add() with three integers");
            int sum2 = ob.Add(1, 2, 3);
            Console.WriteLine("sum: " + sum2);
        }
    }
}
