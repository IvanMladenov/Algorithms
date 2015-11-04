namespace MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = new Dictionary<Node, List<Edge>>();

            int nodes = int.Parse(Regex.Match(Console.ReadLine(), "\\d+").ToString());
            var nodesArr = new Node[nodes];          
            for (int i = 0; i < nodes; i++)
            {
                nodesArr[i] = new Node(i);
                graph.Add(nodesArr[i], new List<Edge>());
            }

            string[] startEnd = Regex.Split(Console.ReadLine(), "[^\\d]+");
            int start = int.Parse(startEnd[1]);
            int end = int.Parse(startEnd[2]);
            Node startNode = nodesArr.FirstOrDefault(x=>x.Id==start);
            Node endNode = nodesArr.FirstOrDefault(x=>x.Id == end);

            int numberOfEdges = int.Parse(Regex.Match(Console.ReadLine(), "\\d+").ToString());
            for (int i = 0; i < numberOfEdges; i++)
            {
                var current = Regex.Split(Console.ReadLine(), "[^\\d]+");
                var firstNode = nodesArr[int.Parse(current[0])];
                var secondNode = nodesArr[int.Parse(current[1])];
                var percentage = double.Parse(current[2]);

                graph[firstNode].Add(new Edge(secondNode, percentage));
                graph[secondNode].Add(new Edge(firstNode, percentage));
            }

            Dijkstra(startNode, graph);
            List<int> path = FindPath(endNode);

            Console.WriteLine(Math.Round(endNode.Reliability, 2));
            Console.WriteLine(string.Join(" -> ", path));
        }

        private static List<int> FindPath(Node endNode)
        {
            List<int> output = new List<int>();
            output.Add(endNode.Id);
            var node = endNode;
            while (true)
            {
                if (node.PrevNode == null)
                {
                    break;
                }

                output.Add(node.PrevNode.Id);
                node = node.PrevNode;
            }

            output.Reverse();
            return output;
        }

        private static void Dijkstra(Node startNode, Dictionary<Node, List<Edge>> graph)
        {
            var priorityQueue = new BinaryHeap<Node>();

            foreach (var node in graph.Keys)
            {
                node.Reliability = double.NegativeInfinity;
            }

            startNode.Reliability = 100.0;
            priorityQueue.Insert(startNode);
            HashSet<Node> visited = new HashSet<Node>();
            visited.Add(startNode);

            while (priorityQueue.Count != 0)
            {
                var current = priorityQueue.ExtractMax();

                if (double.IsNegativeInfinity(current.Reliability))
                {
                    break;
                }

                foreach (var edge in graph[current])
                {
                    var newR = (current.Reliability * edge.Percentage) / 100;
                    if (newR>edge.Node.Reliability)
                    {
                        edge.Node.Reliability = newR;
                        edge.Node.PrevNode = current;
                    }
                    

                    if (!visited.Contains(edge.Node))
                    {                      
                        visited.Add(edge.Node);
                        priorityQueue.Insert(edge.Node);
                    }
                }
            }
        }
    }
}