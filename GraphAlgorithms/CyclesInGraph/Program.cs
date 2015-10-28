namespace CyclesInGraph
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
            FillTheGraph(graph);

            SortedList<char, int> predecessors = new SortedList<char, int>();
            FindPredecessors(graph, predecessors);

            bool nodeRemoved = true;

            foreach (var node in predecessors.Keys)
            {
                while (nodeRemoved)
                {
                    nodeRemoved = false;
                    //foreach (var node in predecessors.Keys)
                    //{
                    if (predecessors[node] <= 1)
                    {
                        foreach (var child in graph[node])
                        {
                            if (predecessors.ContainsKey(child))
                            {
                                predecessors[child]--;
                            }
                        }

                        predecessors.Remove(node);
                        nodeRemoved = true;
                        break;
                    }
                    //}
                }
            }

            Console.WriteLine("Acyclic: {0}", predecessors.Count == 0 ? "Yes" : "No");
        }

        private static void FillTheGraph(Dictionary<char, List<char>> graph)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                char node = line[0];
                char child = line[4];
                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<char>());
                }

                graph[node].Add(child);

                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<char>());
                }

                graph[child].Add(node);
            }
        }

        private static void FindPredecessors(Dictionary<char, List<char>> graph, SortedList<char, int> predecessors)
        {
            foreach (var node in graph.Keys)
            {
                if (!predecessors.ContainsKey(node))
                {
                    predecessors.Add(node, 0);
                }

                foreach (var child in graph[node])
                {
                    if (!predecessors.ContainsKey(child))
                    {
                        predecessors.Add(child, 0);
                    }

                    predecessors[child]++;
                }
            }
        }
    }
}
