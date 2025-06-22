using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class CopyConstractor
    {
        public string p1, p2;
        public int p3, p4;
        public CopyConstractor(string a)
        {
            p1 = a;
        }
        public CopyConstractor(CopyConstractor cc) 
        {
            p1 = cc.p1;
        }
        public CopyConstractor(int a, int b)
        {
            p3 = a;
            p4 = b;
        }
        public CopyConstractor(CopyConstractor cc,CopyConstractor cy)
        {
            p3=cc.p3;
            p4 = cy.p4;
        }
    }
}
