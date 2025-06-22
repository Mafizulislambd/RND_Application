using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankProblemSolving
{
    public class GradingStudent
    {
        public static void MainMethod()
        {
            string outputPath = System.Environment.GetEnvironmentVariable("OUTPUT_PATH") ?? "default_output.txt";
            TextWriter textWriter = new StreamWriter(outputPath, true);


            int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> grades = new List<int>();

            for (int i = 0; i < gradesCount; i++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
                grades.Add(gradesItem);
            }

            List<int> result = gradingStudents(grades);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
        public static List<int> gradingStudents(List<int> grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                int item = grades[i];
                if (item >= 38)
                {
                    int diff = 5 - (item % 5);
                    if (diff < 3)
                        grades[i] = item + diff;
                }
            }
            return grades;
        }

    }
}
