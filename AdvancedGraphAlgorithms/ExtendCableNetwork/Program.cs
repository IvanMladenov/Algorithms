namespace ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            Console.ReadLine();

            List<Edge> edges = new List<Edge>();
            Dictionary<int, bool> conectedNodes = new Dictionary<int, bool>();
            int budget = 0;

            while (true)
            {
                string currentLine = Console.ReadLine();
                if (currentLine.Contains("Budget"))
                {
                    string[] lastLine = currentLine.Split(' ');
                    budget = int.Parse(lastLine[1]);
                    break;
                }

                string[] splitet = currentLine.Split(' ');
                var startNode = int.Parse(splitet[0]);
                var endNode = int.Parse(splitet[1]);
                var weight = int.Parse(splitet[2]);
                var currentEdge = new Edge(startNode, endNode, weight);
                edges.Add(currentEdge);

                if (!conectedNodes.ContainsKey(startNode))
                {
                    conectedNodes.Add(startNode, false);
                }

                if (!conectedNodes.ContainsKey(endNode))
                {
                    conectedNodes.Add(endNode, false);
                }

                if (splitet.Length == 4)
                {
                    conectedNodes[startNode] = true;
                    conectedNodes[endNode] = true;
                }
            }

            edges.Sort();
            int totalWeight = 0;
            foreach (var edge in edges)
            {
                int currentWeight = edge.Weight;
                if (totalWeight+currentWeight>budget)
                {
                    break;
                }

                if ((conectedNodes[edge.StartNode]^conectedNodes[edge.EndNode])
                    ||(!conectedNodes[edge.StartNode]&&!conectedNodes[edge.EndNode]))
                {
                    totalWeight += edge.Weight;
                    conectedNodes[edge.StartNode] = true;
                    conectedNodes[edge.EndNode] = true;
                    Console.WriteLine(edge);
                }
            }

            Console.WriteLine("Budget used: " + totalWeight);
        }
    }
}