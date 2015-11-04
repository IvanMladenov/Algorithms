namespace ShortestPathWithNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Regex.Match(Console.ReadLine(), "\\d+").ToString());
            int[] nodes = new int[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes[i] = i;
            }

            int numberOfEdges = int.Parse(Regex.Match(Console.ReadLine(), "\\d+").ToString());
            Edge[] edges = new Edge[numberOfEdges];
            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] currentLine = Console.ReadLine().Split(' ');
                Edge current = new Edge(int.Parse(currentLine[0]), int.Parse(currentLine[1]), double.Parse(currentLine[2]));
                edges[i] = current;
            }


            BelmondFord(nodes, edges, 0);
        }

        private static void BelmondFord(int[] nodes, Edge[] edges, int startNode)
        {
            int[] predcessors = new int[nodes.Length];
            double[] distance = new double[nodes.Length];

            //Initialize parents and default distances
            for (int i = 0; i < nodes.Length; i++)
            {
                predcessors[i] = -1;
                distance[i] = Double.PositiveInfinity;
            }

            distance[startNode] = 0;

            //Calculate distances and find the path
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                foreach (var edge in edges)
                {
                    if (distance[edge.StartNode] + edge.Distance < distance[edge.EndNode])
                    {
                        distance[edge.EndNode] = distance[edge.StartNode] + edge.Distance;
                        predcessors[edge.EndNode] = edge.StartNode;
                    }
                }
            }

            List<int> path = new List<int>();
            bool hasCycle = false;
            //Check for cycles
            foreach (var edge in edges)
            {
                if (distance[edge.StartNode] + edge.Distance < distance[edge.EndNode])
                {
                    hasCycle = true;
                    int current = edge.StartNode;
                    path.Add(current);
                    while (true)
                    {
                        current = predcessors[current];
                        if (current == edge.StartNode)
                        {
                            break;
                        }

                        path.Add(current);
                    }
                    path.Reverse();
                    Console.WriteLine("Negative cycle detected:" + Environment.NewLine + string.Join(" -> ", path));
                }
            }

            if (!hasCycle)
            {
                int current = nodes.Length - 1;
                while (current != -1)
                {
                    path.Add(current);
                    current = predcessors[current];
                }
                path.Reverse();
                Console.WriteLine("Distance [{0} -> {1}]: {3}\nPath: {2}",
                    0,
                    nodes.Length - 1,
                    string.Join(" -> ", path),
                    distance[nodes.Length - 1]);
            }
        }
    }
}
