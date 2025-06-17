using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
    internal class ActiveTraders
    {
        public static List<string> MostActive(List<string> customers)
        {
            Dictionary<string, int> customerCount = new Dictionary<string, int>();
            int total = customers.Count;

            foreach (var customer in customers)
            {
                if (customerCount.ContainsKey(customer))
                    customerCount[customer]++;
                else
                    customerCount[customer] = 1;
            }

            var result = customerCount
                .Where(kvp => (double)kvp.Value / total >= 0.05)
                .Select(kvp => kvp.Key)
                .OrderBy(name => name)
                .ToList();

            return result;
        }
        public static void MainMethod()
        {
            int customersCount = Convert.ToInt32(Console.ReadLine());
            List<string> customers = new List<string>();

            for (int i = 0; i < customersCount; i++)
            {
                string customerName = Console.ReadLine();
                customers.Add(customerName);
            }

            List<string> result = MostActive(customers);

            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}
