using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class EncapsulationClass
    {
        private String studentName;
        private int studentAge;

        public String Name
        {
            get { return studentName; }

            set { studentName = value; }
        }

        // using accessors to get and
        // set the value of studentAge
        public int Age
        {
            get { return studentAge; }

            set { studentAge = value; }
        }
    }
    public class BankAccount
    {
        private decimal balance;

        // Constructor
        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        // Deposit Method
        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        // Withdraw Method
        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        // Check the Balance of Account
        public decimal GetBalance()
        {
            return balance;
        }
    }
    abstract class Shape
    {

        // abstract method
        // No direct access
        public abstract int area();
    }

    // square class inheriting
    // the Shape class
    class Square : Shape
    {

        // private data member
        private int side;

        // method of square class
        public Square(int x = 0)
        {
            side = x;
        }

        // overriding of the abstract method of Shape
        // class using the override keyword
        public override int area()
        {
            Console.Write("Area of Square: ");
            return (side * side);
        }
    }


}
