using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
    internal class PasswordDecryption
    {
        public static string DecryptPassword(string s)
        {
            Stack<char> digitStack = new Stack<char>();
            StringBuilder result = new StringBuilder();

            int i = 0;
            while (i < s.Length)
            {
                // If digit 1–9, push to stack
                if (char.IsDigit(s[i]) && s[i] != '0')
                {
                    digitStack.Push(s[i]);
                    i++;
                }
                // If '0', pop from stack and append
                else if (s[i] == '0')
                {
                    if (digitStack.Count > 0)
                        result.Append(digitStack.Pop());
                    i++;
                }
                // If pattern: Upper + Lower + '*', reverse and append
                else if (i + 2 < s.Length && char.IsUpper(s[i]) && char.IsLower(s[i + 1]) && s[i + 2] == '*')
                {
                    result.Append(s[i + 1]); // lowercase first
                    result.Append(s[i]);     // then uppercase
                    i += 3; // Skip 3 chars
                }
                // Otherwise, append the character as is
                else
                {
                    result.Append(s[i]);
                    i++;
                }
            }

            return result.ToString();
        }
       public static void MainMethod()
        {
            Console.Write("Enter encrypted password: ");
            string s = Console.ReadLine();

            string result = DecryptPassword(s);
            Console.WriteLine("Decrypted password: " + result);
        }
    }
}
