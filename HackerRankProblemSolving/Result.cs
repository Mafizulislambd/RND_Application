using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
    internal class Result
    {
        public static int lowestTriangle(int trianglebase, int area)
        {
            return (int)Math.Ceiling((float)(2 * area) / trianglebase);
        }
        public static int gameWithCells(int n, int m)
        {
            if( m<=1 && n<=1)
                return 1;
            return (n / 2 + n % 2) * (m / 2 + m % 2);
        }
        public static int ArmyGame()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int m = Convert.ToInt32(Console.ReadLine());

            int result = Result.gameWithCells(n, m);

            return result;
        }
    }
}
