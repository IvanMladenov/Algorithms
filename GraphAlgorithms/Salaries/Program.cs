namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            Dictionary<int, decimal> calculatedSalaries = new Dictionary<int, decimal>();
            for (int i = 0; i < n; i++)
            {
                CalculateSalary(graph, i, calculatedSalaries);
            }

            decimal total = calculatedSalaries.Sum(x => x.Value);
            Console.WriteLine(total);
        }

        private static void CalculateSalary(List<int>[] graph, int i, Dictionary<int, decimal> calculated)
        {
            if (!calculated.ContainsKey(i))
            {
                calculated.Add(i, 0);
                if (graph[i].Count > 0)
                {
                    foreach (var employee in graph[i])
                    {
                        CalculateSalary(graph, employee, calculated);
                        calculated[i] += calculated[employee];
                    }
                }
                else
                {
                    calculated[i]++;
                }
            }
        }
    }
}