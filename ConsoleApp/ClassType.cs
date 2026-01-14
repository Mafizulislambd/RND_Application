using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day = System.DayOfWeek;

namespace ConsoleApp
{
    internal class ClassType
    {
        public int MyProperty { get; set; }
        SealedClass SealedClass = new SealedClass();
    }
    public static class StaticClass
    {
        public static int ID { get; set; }
        public static string Name { get; set; }
    }
    public partial class PartialClass
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

    public abstract class AbstracCls
    {

        public int MyProperty { get; set; }
    }

    public sealed class SealedClass
    {
        public const int xvar = 20;
        public const string str = "InterviewBit";
        public readonly int xvar1;
        public readonly int yvar2;
        public SealedClass()
        {
            xvar1 = 5; // Initializing readonly field
            yvar2 = 15; // Initializing readonly field
        }
        public int SID { get; set; }
        public int Sname { get; set; }

        public void Display()
        {
            string s = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                s += i.ToString() + " ";
                Console.WriteLine(s);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i);
                Console.WriteLine(sb.Append(' '));

            }
            Console.WriteLine("The value of xvar: {0}", xvar);
            Console.WriteLine("The value of str: {0}", str);

            Console.WriteLine("The value of xvar1: {0}", xvar1);
            Console.WriteLine("The value of yvar2: {0}", yvar2);
        }
    }
    public class Area
    {
        public double area(double x)
        {

            double area = x * x;
            return area;
        }
        public double area(double a, double b)
        {
            double area = a * b;
            return area;
        }
    }
    public class TempRecord
    {
        // Array of temperature values
        float[] temps =
        [
            56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
        ];

        // To enable client code to validate input
        // when accessing your indexer.
        public int Length => temps.Length;

        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }
    }
    // Using a string as an indexer value
    class DayCollection
    {
        string[] days = ["Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat"];

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[string day] => FindDayIndex(day);

        private int FindDayIndex(string day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }

            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
        }
    }

    class DayOfWeekCollection
    {
        Day[] days =
        [
            Day.Sunday, Day.Monday, Day.Tuesday, Day.Wednesday,
        Day.Thursday, Day.Friday, Day.Saturday
        ];

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[Day day] => FindDayIndex(day);

        private int FindDayIndex(Day day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }
            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be a defined System.DayOfWeek value.");
        }
    }
}
