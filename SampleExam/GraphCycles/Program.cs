using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphCycles
{
    class Program
    {
        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes];
            BuildGraph(graph);

            bool hasCycle = false;
            for (int i = 0; i < graph.Length; i++)
            {
                foreach (var second in graph[i])
                {
                    if (second > i)
                    {
                        foreach (var third in graph[second])
                        {
                            if (third > i && third != second)
                            {
                                if (graph[third].Contains(i))
                                {
                                    Console.WriteLine("{" + $"{i} -> {second} -> {third}" + "}");
                                    hasCycle = true;
                                }
                            }
                        }
                    }
                }
            }

            if (!hasCycle)
            {
                Console.WriteLine("No cycles found");
            }
        }

        private static void BuildGraph(List<int>[] graph)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentNode = line[0];
                graph[currentNode] = new List<int>();
                for (int j = 1; j < line.Length; j++)
                {
                    if (!graph[currentNode].Contains(line[j]))
                    {
                        graph[currentNode].Add(line[j]);
                    }
                }
                graph[currentNode].Sort();
            }
        }
    }
}
