// See https://aka.ms/new-console-template for more information
using TestCSharp;

Console.WriteLine("Hello, World!");
//byte a = 0;

// sbyte is 8 bit
// singned value
//Console.WriteLine(a);

//a++;
//Console.WriteLine(a);

//// It overflows here because
//// byte can hold values
//// from -128 to 127
//a++;
//Console.WriteLine(a);

//// Looping back within
//// the range
//a++;
//Console.WriteLine(a); 
//int n = 10;

//// store variable n address 
//// location in pointer variable p

//int num = Convert.ToInt32(Console.ReadLine());

//// printing the result
//Console.WriteLine("Value of num is " + num);// decimal-form literal
//int az = 101;

//// Hexa-decimal form literal
//int cz = 0xFace;

//// binary-form literal
//int xz = 0b101;

//Console.WriteLine(az);
//Console.WriteLine(cz);
//Console.WriteLine(xz);

int a = 10;

// Using different assignment operators
a += 5;
Console.WriteLine("Add Assignment: " + a);

a -= 3;
Console.WriteLine("Subtract Assignment: " + a);

a *= 2;
Console.WriteLine("Multiply Assignment: " + a);

a /= 4;
Console.WriteLine("Division Assignment: " + a);

a %= 5;
Console.WriteLine("Modulo Assignment: " + a); 
int x = 10;

// Binary representation: 0010
int y = 2;

// Bitwise AND 
Console.WriteLine(x & y);

// Bitwise OR 
Console.WriteLine(x | y);

// Bitwise XOR 
Console.WriteLine(x ^ y);

// Bitwise NOT 
Console.WriteLine(~x);

// Shifting bit by one on the left
Console.WriteLine(x << 1);

// Shifting bit by one on the right
Console.WriteLine(x >> 1);
int p = 100, q = 15;
// similar to if else

string result = (p > q) ? "p" : "q";
Console.WriteLine(result + " is greater");
string names = null;

// Name have null value takes default
// value instead of null
string results = names ?? "Default Name";


Console.WriteLine(results);

bool ab = true, bc = false;

// return true when both condtions are true
Console.WriteLine(ab && bc);

// return true if any of one is true
Console.WriteLine(ab || bc);

// perform conjuction and negate the condition
Console.WriteLine(!ab);
Student s = new Student();

// Calls set accessor of the property Name  
s.Name = "GFG";

// Calls get accessor of the property Name  
Console.WriteLine("Name: " + s.Name);

// Using 'get' and 'set' as identifiers (contextual usage)
int get = 50;
int set = 70;

Console.WriteLine("Value of get is: {0}", get);
Console.WriteLine("Value of set is: {0}", set);

int number = 20;

// Using Switch case 
switch (number)
{
    case 5:
        Console.WriteLine("case 5");
        break;
    case 10:
        Console.WriteLine("case 10");
        break;
    case 20:
        Console.WriteLine("case 20");

        // goto statement transfers 
        // control to case 5
        goto case 5;

    default:
        Console.WriteLine("No match found");
        break;
}// because of break statement
for (int i = 1; i < 4; i++)
{
    if (i == 3)
        continue;

    Console.WriteLine("GeeksforGeeks");
}
Geeks ob = new Geeks();

int sum1 = ob.Add(1, 2);
Console.WriteLine("add() with two integers");
Console.WriteLine("sum: " + sum1);

Console.WriteLine("add() with three integers");
int sum2 = ob.Add(1, 2, 3);
Console.WriteLine("sum: " + sum2);

Console.WriteLine("Add() with double parameter");

double sum3 = Geeks.Add(1.0, 2.0, 3.0);
Console.WriteLine("sum: " + sum3);




///////////////////////
Geeks obj = new Geeks();

// by changing the order 
obj.Identity("Geek", 1);
obj.Identity(2, "Geek2");

Geeks.addstr(s1: "Geeks", s2: " for",s3:" Geeks");

string val = "Dog";

// Pass as a reference parameter 
Geeks.CompareValue(ref val);

// Display the given value 
Console.WriteLine(val);

int num;

// Pass variable num to the method 
// using out keyword 
Geeks.AddNum(out num);

// Display the value of num 
Console.WriteLine("The sum of"
  + " the value is: {0}", num);

Geeks.detail("XYZ", 123);
Geeks.detail("ABC", 456, "B-");
Geeks.detail("DEF", 789, "B+",
   "Software Developer");


Geeks.mulval("test");
int px = Geeks.mulval(20, 49, 56, 69, 78, 100);

// show result 
Console.WriteLine(px);
Dog d = new Dog();

d.Move();
d.Eat();
d.Bark();
Animal animal = new Animal();
animal.Move();
ArrayClass.ArrayExampley();

Console.WriteLine("Jugged Array Example");
ArrayClass.juggedArray();


Console.WriteLine("Array Shorts");
ArrayShort.ArrayShorts();


Console.WriteLine("Encapsulation Example");

EncapsulationClass encapsulationClass = new EncapsulationClass();
encapsulationClass.Name = "Sumon";
encapsulationClass.Age = 34;
Console.WriteLine("Name :" + encapsulationClass.Name);
Console.WriteLine("Age :" + encapsulationClass.Age);

BankAccount myAccount = new BankAccount(1000);

myAccount.Deposit(500);
Console.WriteLine("Balance: " + myAccount.GetBalance());

myAccount.Withdraw(2000);
Console.WriteLine("Balance: " + myAccount.GetBalance());



// which refer to Square class instance
Shape sh = new Square(4);

// calling the method
double resulte = sh.area();

Console.Write("{0}", resulte);

Console.WriteLine("Encapsulation Example");
IDumpable Car = new BMW(90);

Car.Command = DriveCommand.PETROL;
Car.Dump();

Car.Command = DriveCommand.DIESEL;
Car.Dump();

Car = new TRUCK(100);

Car.Command = DriveCommand.DIESEL;
Car.Dump();

Car = new TUCSON(80);

Car.Command = DriveCommand.PETROL;
Car.Dump();

Car.Command = DriveCommand.ELECTRIC;
Car.Dump();

Car = new WAGONR(50);

Car.Command = DriveCommand.CNG;
Car.Dump();

Geek objext = new Geek();

// calling the method 
// using object 'obj'
objext.mymethod1();
objext.mymethod2();
objext.mymethod3();


//Creating the objects of 
        // TechinalScriptWriter class
        TechnicalScriptWriter objezt = new TechnicalScriptWriter();

// calling the methods by passing
// the required values
objezt.vote_no(470045);
objezt.detailsofauthor("Siya", 98);

ColorRectangle r1 = new ColorRectangle("pink",
                   "Fibonacci rectangle", 2.0, 3.236);

ColorRectangle r2 = new ColorRectangle("black",
                           "Square", 4.0, 4.0);

Console.WriteLine("Details of r1: ");
r1.DisplayStyle();
r1.DisplayDim();
r1.DisplayColor();

Console.WriteLine("Area is " + r1.Area());
Console.WriteLine();

Console.WriteLine("Details of r2: ");
r2.DisplayStyle();
r2.DisplayDim();
r2.DisplayColor();

Console.WriteLine("Area is " + r2.Area());

////////////////////
Console.ReadKey();
public class Student
{
    // Declare name field  
    private string name = "GeeksforGeeks";

    // Declare Name property  
    public string Name
    {
        // 'get' is a contextual keyword 
        get
        {
            return name;
        }

        // 'set' is a contextual keyword 
        set
        {
            name = value;
        }
    }
}
