using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class InterfaceClass
    {
    }
    public enum DriveCommand
    {
        PETROL,
        DIESEL,
        CNG,
        ELECTRIC
    }
    public interface IDumpable
    {
        DriveCommand Command
        {
            get;
            set;
        }
        void Dump();
    }
    public class BMW : IDumpable
    {
        private DriveCommand _command;
        private int _speed;

        public DriveCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public BMW(int Speed)
        {
            this._speed = Speed;
        }

        public void Dump()
        {
            Console.WriteLine("I AM DRIVING BMW");
            Console.WriteLine("Command : " + _command);

            if (_command == DriveCommand.PETROL)
            {
                Console.WriteLine("BMW IS NOW DRIVING ON " + _command +
                 " WITH SPEED OF " + _speed.ToString() + " KM/HR" + "\n");
            }
            else
            {
                Console.WriteLine("BMW IS NOT COMPATIBLE TO DRIVE ON " + _command + "\n");
            }
        }
    }
    public class TRUCK : IDumpable
    {
        private DriveCommand _command;
        private int _speed;

        public DriveCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public TRUCK(int Speed)
        {
            this._speed = Speed;
        }

        public void Dump()
        {
            Console.WriteLine("I AM DRIVING TRUCK");
            Console.WriteLine("Command : " + _command);

            if (_command == DriveCommand.DIESEL)
            {
                Console.WriteLine("TRUCK IS NOW DRIVING ON " +
                _command + " WITH SPEED OF " + _speed.ToString()
                + " KM/HR" + "\n");
            }
            else
            {
                Console.WriteLine("TRUCK IS NOT COMPATIBLE   TO DRIVE ON " + _command + "\n");
            }
        }
    }

    public class TUCSON : IDumpable
    {
        private DriveCommand _command;
        private int _speed;

        public DriveCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public TUCSON(int Speed)
        {
            this._speed = Speed;
        }

        public void Dump()
        {
            Console.WriteLine("I AM DRIVING TUCSON");
            Console.WriteLine("Command : " + _command);

            if (_command == DriveCommand.PETROL
            || _command == DriveCommand.ELECTRIC)
            {
                Console.WriteLine("TUCSON IS NOW DRIVING ON " + _command
                + " WITH SPEED OF " + _speed.ToString() + " KM/HR" + "\n");
            }
            else
            {
                Console.WriteLine("TUCSON IS NOT   COMPATIBLE TO DRIVE ON " + _command + "\n");
            }
        }
    }

    public class WAGONR : IDumpable
    {
        private DriveCommand _command;
        private int _speed;

        public DriveCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public WAGONR(int Speed)
        {
            this._speed = Speed;
        }

        public void Dump()
        {
            Console.WriteLine("I AM DRIVING WAGONR");
            Console.WriteLine("Command : " + _command);

            if (_command == DriveCommand.PETROL || _command == DriveCommand.CNG)
            {
                Console.WriteLine("WAGONR IS NOW DRIVING ON " + _command
                + " WITH SPEED OF " + _speed.ToString() + " KM/HR" + "\n");
            }
            else
            {
                Console.WriteLine("WAGONR IS NOTCOMPATIBLE TO DRIVE ON " + _command + "\n");
            }
        }
    }
    public interface A
    {

        // method of interface
        void mymethod1();
        void mymethod2();
    }

    // The methods of interface A 
    // is inherited into interface B
    public interface B : A
    {

        // method of interface B
        void mymethod3();
    }


    // Below class is inheriting
    // only interface B
    // This class must 
    // implement both interfaces
    class Geek : B
    {

        // implementing the method
        // of interface A
        public void mymethod1()
        {
            Console.WriteLine("Implement method 1");
        }

        // Implement the method 
        // of interface A
        public void mymethod2()
        {
            Console.WriteLine("Implement method 2");
        }

        // Implement the method
        // of interface B
        public void mymethod3()
        {
            Console.WriteLine("Implement method 3");
        }
    }
    public interface Votes
    {

        // method of interface 
        void vote_no(int a);
    }

    // The methods of interface Votes
    // is inherited into interface Details
    public interface Details : Votes
    {

        // method of interface Details
        void detailsofauthor(string n, int p);
    }
    class TechnicalScriptWriter : Details
    {
        // implementing the method 
        // of interface Votes
        public void vote_no(int a)
        {
            Console.WriteLine("Total number of votes is: {0}", a);
        }

        // implementing the method 
        // of interface Details 
        public void detailsofauthor(string n, int p)
        {
            Console.WriteLine("Name of the author is: {0}", n);

            Console.WriteLine("Total number of published" +
                                    " article is: {0}", p);
        }
    }
}
