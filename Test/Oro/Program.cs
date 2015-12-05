using System;
using System.Collections.Generic;
using System.Linq;

namespace Oro
{
    internal class Program
    {
        private static HashSet<int> visited;

        private static void Main(string[] args)
        {
            var numberOfEdges = int.Parse(Console.ReadLine());
            var leader = int.Parse(Console.ReadLine());

            var graph = new Dictionary<int, List<int>>();
            for (var i = 0; i < numberOfEdges; i++)
            {
                var currentLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (!graph.ContainsKey(currentLine[0]))
                {
                    graph[currentLine[0]] = new List<int>();
                }

                if (!graph.ContainsKey(currentLine[1]))
                {
                    graph[currentLine[1]] = new List<int>();
                }

                graph[currentLine[0]].Add(currentLine[1]);
                graph[currentLine[1]].Add(currentLine[0]);
            }

            if (!graph.ContainsKey(leader))
            {
                Console.WriteLine(0);
                return;
            }

            visited = new HashSet<int>();

            var maxDepth = 1;
            visited.Add(leader);
            DFS(graph, leader, maxDepth, ref maxDepth);

            Console.WriteLine(maxDepth);
        }

        private static void DFS(Dictionary<int, List<int>> graph, int root, int depth, ref int maxDepth)
        {
            foreach (var child in graph[root])
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    DFS(graph, child, depth + 1, ref maxDepth);
                }

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }
        }
    }
}