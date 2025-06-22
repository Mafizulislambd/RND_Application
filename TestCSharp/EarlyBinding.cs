using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    internal class EarlyBinding
    {
        public string name;
        public string subject;

        // public method
        public void details(string name, string subject)
        {
            this.name = name;
            this.subject = subject;
            Console.WriteLine("Myself: " +name);
            Console.WriteLine("&quot; My Favorite Subject is: &quot;" +subject);
        }
    }
}
