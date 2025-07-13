using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ArrayClass
    {
        internal static bool FindPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            var squareRoot = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= squareRoot; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        internal static void findallsubstring(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                StringBuilder subString = new StringBuilder(str.Length - i);
                for (int j = i; j < str.Length; ++j)
                {
                    subString.Append(str[j]);
                    Console.Write(subString + " ");
                }
            }
        }

        internal static void chkPalindrome(string str)
        {
            bool flag = false;
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                Char s = str[i];
                Char y = str[j];
                if (s != y)
                {
                    flag = false;
                    break;
                }
                else
                    flag = true;
            }
            if (flag)
            {
                Console.WriteLine("Palindrome");
            }
            else
                Console.WriteLine("Not Palindrome");
        }
        internal static void ReverseWordOrder(string str)
        {
            int i;
            StringBuilder reverseSentence = new StringBuilder();
            int Start = str.Length - 1;
            int End = str.Length - 1;
            while (Start > 0)
            {
                if (str[Start] == ' ')
                {
                    i = Start + 1;
                    while (i <= End)
                    {
                        reverseSentence.Append(str[i]);
                        i++;
                    }
                    reverseSentence.Append(' ');
                    End = Start - 1;
                }
                Start--;
            }
            for (i = 0; i <= End; i++)
            {
                reverseSentence.Append(str[i]);
            }
            Console.WriteLine(reverseSentence.ToString());
        }
        internal static void ReverseString(string str)
        {

            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedstring = new string(charArray);
            Console.WriteLine(reversedstring);
        }
       public static void func(ref int[] x)
        {
            Console.Write(" numbers are : ");
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    x[i] = x[i] + 1;
                    Console.Write(x[i] + " ");
                }
            }
        }
    }
}
