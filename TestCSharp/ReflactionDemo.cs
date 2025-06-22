using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class ReflactionDemo
    {
        Type t = typeof(string);
        MethodInfo MethodInfo = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
        public void ReflectionType()
        {
            // Display the type of t
            Console.WriteLine("Type of t: " + t);
            // Display the full name of the type
            Console.WriteLine("Full Name of t: " + t.FullName);
            // Display the namespace of the type
            Console.WriteLine("Namespace of t: " + t.Namespace);
            // Display the assembly of the type
            Console.WriteLine("Assembly of t: " + t.Assembly);
            // Display the base type of the type
            Console.WriteLine("Base Type of t: " + t.BaseType);
        }

        public void ReflectionMethodInfo()
        {
            // Display the name of the method
            Console.WriteLine("Method Name: " + MethodInfo.Name);
            // Display the return type of the method
            Console.WriteLine("Return Type: " + MethodInfo.ReturnType);
            // Display the parameters of the method
            ParameterInfo[] parameters = MethodInfo.GetParameters();
            Console.WriteLine("Parameters:");
            foreach (var param in parameters)
            {
                Console.WriteLine($"- {param.Name} : {param.ParameterType}");
            }
        }
        public void ReflectionAssemblyTypes()
        {
            // Get the executing assembly and display its types
            Console.WriteLine("Types in the executing assembly:");
            Assembly executing = Assembly.GetExecutingAssembly();
            Type[] types = executing.GetTypes();
            foreach (var item in types)
            {
                // Display each type
                Console.WriteLine("Class : {0}", item.Name);

                // Array to store methods
                MethodInfo[] methods = item.GetMethods();
                foreach (var method in methods)
                {
                    // Display each method
                    Console.WriteLine("--> Method : {0}", method.Name);

                    // Array to store parameters
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var arg in parameters)
                    {
                        // Display each parameter
                        Console.WriteLine("----> Parameter : {0} Type : {1}",
                                                arg.Name, arg.ParameterType);
                    }
                }
            }
        }

    }
    class StudentInfo
    {

        // Properties definition
        public int RollNo
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        // No Argument Constructor
        public StudentInfo()
        {
            RollNo = 0;
            Name = string.Empty;
        }

        // Parameterised Constructor
        public StudentInfo(int rno, string n)
        {
            RollNo = rno;
            Name = n;
        }

        // Method to Display Student Data
        public void displayData()
        {
            Console.WriteLine("Roll Number : {0}", RollNo);
            Console.WriteLine("Name : {0}", Name);
        }
    }
}
