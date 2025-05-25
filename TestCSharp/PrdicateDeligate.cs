using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class PrdicateDeligate
    {
        public delegate bool my_delegate(string mystring);

        // Method
        public static bool myfun(string mystring)
        {
            if (mystring.Length < 7)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
