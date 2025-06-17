using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
    internal class Leonardo_Prime_Factors
    {
        public Leonardo_Prime_Factors()
        {
            
        }
        public static int primeCount(long n)
        {
            List<int> primes = new List<int>
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
            31, 37, 41, 43, 47, 53, 59, 61, 67,
            71, 73, 79, 83, 89, 97
        };

            ulong product = 1;
            int count = 0;

            if (n == 1)
            {
                return count;
            }

            foreach (int prime in primes)
            {
                product *= (ulong)prime;

                if (product > (ulong)n)
                    break;

                count++;

                if (product == (ulong)n)
                    break;
            }

            return count;
        }
        public static void MainMehod()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine().Trim());

                int result = primeCount(n);

                Console.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }

    }
}
