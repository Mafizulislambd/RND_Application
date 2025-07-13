// See https://aka.ms/new-console-template for more information
using ConsoleApp;
using System;
using System.Collections;
using System.Reflection;
Console.WriteLine("Hello, World!");
//for (int j = 1; j <= 115; j = j + 10)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", j);
//}
//int i = 1;
//while (i <= 1000015)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", i);
//    if (i + 1000 > 1000015)
//        i = 1000015; // Force last iteration to 1000015
//    else
//        i += 1000;
//}
//int j = 0;
//while (j <= 115)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", j);
//    if (j + 10 > 115) // If next step would skip 115
//        j = 115;  // Jump directly to 115
//    else
//        j += 10;
//}
//for (int j = 0; j <= 115; j = j + 10)
//{
//    Console.WriteLine("C# For Loop: Iteration {0}", j);

//    if (j + 10 > 115 && j != 115) // If the next step exceeds 115
//    {
//        j = 115 - 10; // Adjust before the next iteration
//    }
//}
for (int j = 0; j <= 115; j = j + 10)
{
    Console.WriteLine("C# For Loop: Iteration {0}", j);
}

#region ArrayList Example
CustomArrayList.AddElement();
// Example usage of the CustomArrayList class
#endregion
string firstName="";
//firstName = ListItem.GetFirstItem("names");
Console.WriteLine("First name: " + firstName);
#region Bank Account Example
Console.WriteLine("Welcome to the Bank App!");

// TASK 5: Display Basic Bank Account Information
Customer customer = new Customer
{
    Name = "John Doe",
    CustomerId = "C12345",
    Address = "123 Main St"
};

BankAccount account = new BankAccount(12345678, 500, customer, AccountType.Checking);
Console.WriteLine(account.DisplayAccountInfo());

// TASK 6: Perform Transactions
account.Deposit(200, "Paycheck");
Console.WriteLine("After deposit:");
Console.WriteLine(account.DisplayAccountInfo());

bool success = account.Withdraw(100, "Groceries");
Console.WriteLine(success ? "Withdrawal successful." : "Withdrawal failed.");
Console.WriteLine("After withdrawal:");
Console.WriteLine(account.DisplayAccountInfo());

// TASK 7: Display Transaction History
account.DisplayTransactions();



#endregion
#region

SealedClass sealedClass = new SealedClass();
sealedClass.Display();

#endregion
#region Indexer Example
var tempRecord = new TempRecord();
tempRecord[3] = 58.3F;
tempRecord[5] = 60.1F;
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Element #{i} = {tempRecord[i]}");
}

var week = new DayCollection();
Console.WriteLine(week["Fri"]);

try
{
    Console.WriteLine(week["Made-up day"]);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine($"Not supported input: {e.Message}");
}

var weeks = new DayOfWeekCollection();
Console.WriteLine(weeks[DayOfWeek.Friday]);

try
{
    Console.WriteLine(weeks[(DayOfWeek)43]);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine($"Not supported input: {e.Message}");
}
#endregion

#region Prime Number
if (ArrayClass.FindPrime(53))
{
    Console.WriteLine("Prime");
}
else
{
    Console.WriteLine("Not Prime");
}
#endregion
#region Substring
ArrayClass.findallsubstring("Adog");
Console.WriteLine();
ArrayClass.chkPalindrome("madam");
ArrayClass.ReverseWordOrder("xyxmto");
ArrayClass.ReverseString("abcdef");


int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
ArrayClass.func(ref a);
#endregion
#region Delegate Example
Console.WriteLine("Delegate Example:");
MyDelegate del = DelegateClass.PrintMsg;
del("Hello, World!");
del += DelegateClass.Method1;
del += DelegateClass.Method2;
del("This is a delegate example.");
string name = "hello world";
Console.WriteLine(name.ToTitleCase());
#endregion
#region Reflaction
Type type = typeof(string);
Assembly assembly = Assembly.GetExecutingAssembly();
Console.WriteLine(type.FullName);
Console.WriteLine(assembly.FullName);
MethodInfo method = typeof(Console).GetMethod("WriteLine", new[] { typeof(string) });
method.Invoke(null, new object[] { "Hello, Reflection!" });
#endregion
int num = 10;
object boxed = num; // Boxing (value → object)
int unboxed = (int)boxed; // Unboxing (object → value)


Console.ReadKey();
