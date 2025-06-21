using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
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

}
