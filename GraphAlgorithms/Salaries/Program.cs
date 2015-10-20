namespace _3.CyclesInAGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CyclesInAGraph
    {
        private static Dictionary<string, List<string>> graph;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();

            Console.WriteLine("Insert node verticies each on a new line in format A - B (type \"end\" whenever you are ready):");
            string nodeVertex = Console.ReadLine();
            while (nodeVertex.Trim().ToLower() != "end")
            {
                string[] tokens = nodeVertex.Trim().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string parent = tokens[0];
                string child = tokens[1];

                if (!graph.ContainsKey(parent))
                {
                    graph[parent] = new List<string>();
                }

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<string>();
                }

                graph[parent].Add(child);
                graph[child].Add(parent);

                nodeVertex = Console.ReadLine();
            }

            bool acycleGraph = CheckIfGraphIsAcycle();
            Console.WriteLine(acycleGraph);
        }

        private static bool CheckIfGraphIsAcycle()
        {
            var predecessorsCount = new Dictionary<string, int>();
            foreach (var node in graph)
            {
                if (!predecessorsCount.ContainsKey(node.Key))
                {
                    predecessorsCount[node.Key] = 0;
                }

                foreach (var childNode in node.Value)
                {
                    if (!predecessorsCount.ContainsKey(childNode))
                    {
                        predecessorsCount[childNode] = 0;
                    }

                    predecessorsCount[childNode]++;
                }
            }

            while (true)
            {
                string nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorsCount[n] <= 1);
                if (nodeToRemove == null) break;

                foreach (var vertex in graph[nodeToRemove])
                {
                    predecessorsCount[vertex]--;
                    graph[vertex].Remove(nodeToRemove);
                }

                graph.Remove(nodeToRemove);
            }

            if (graph.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}