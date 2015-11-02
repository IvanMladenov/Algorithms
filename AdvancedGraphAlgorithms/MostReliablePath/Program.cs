namespace MostReliablePath
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int nodes = 7;
            var nodesArr = new Node[nodes];
            for (int i = 0; i < nodes; i++)
            {
                nodesArr[i] = new Node(i);
            }
            int edges = 10;
            Node startNode = nodesArr[0];
            Node endNode = nodesArr[6];

            var graph = new Dictionary<Node, List<Edge>>
                            {
                                {
                                    nodesArr[0],
                                    new List<Edge>
                                        {
                                            new Edge(nodesArr[3], 85),
                                            new Edge(nodesArr[4], 88)
                                        }
                                },
                                {
                                    nodesArr[1],
                                    new List<Edge>
                                        {
                                            new Edge(nodesArr[3], 95),
                                            new Edge(nodesArr[6], 100),
                                            new Edge(nodesArr[5], 5)
                                        }
                                },
                                {
                                    nodesArr[2],
                                    new List<Edge>
                                        {
                                            new Edge(nodesArr[4], 14),
                                            new Edge(nodesArr[6], 95)
                                        }
                                },
                                {
                                    nodesArr[3],
                                    new List<Edge>
                                        {
                                            new Edge(nodesArr[0], 85),
                                            new Edge(nodesArr[5], 98),
                                            new Edge(nodesArr[1], 95)
                                        }
                                },
                                {
                                    nodesArr[4],
                                    new List<Edge>
                                        {
                                            new Edge(nodesArr[0], 88),
                                            new Edge(nodesArr[5], 99),
                                            new Edge(nodesArr[2], 14)
                                        }
                                },
                                {
                                    nodesArr[5],
                                    new List<Edge>
                                        {
                                            new Edge(nodesArr[3], 98),
                                            new Edge(nodesArr[1], 5),
                                            new Edge(nodesArr[4], 99),
                                            new Edge(nodesArr[6], 90)
                                        }
                                }
                            };

            Dijkstra(startNode, graph);
            //List<int> path = FindPath(graph, startNode, endNode);
            Console.WriteLine(nodesArr[6].Reliability);
        }

        private static List<int> FindPath(Dictionary<Node, List<Edge>> graph, Node startNode, Node endNode)
        {
            List<int> output = new List<int>();

            while (true)
            {
                
            }

            return output;
        }

        private static void Dijkstra(Node startNode, Dictionary<Node, List<Edge>> graph)
        {
            var priorityQueue = new PriorityQueue<Node>();

            foreach (var node in graph.Keys)
            {
                node.Reliability = double.PositiveInfinity;
            }

            startNode.Reliability = 100.0;
            priorityQueue.Enqueue(startNode);

            while (priorityQueue.Count!=0)
            {
                var current = priorityQueue.Dequeue();

                if (double.IsPositiveInfinity(current.Reliability))
                {
                    break;
                }

                foreach (var edge in graph[current])
                {
                    var newR = (current.Reliability * edge.Percentage);
                    if (newR>edge.Node.Reliability)
                    {
                        edge.Node.Reliability = newR;
                        edge.Node.PrevNode = current;
                        priorityQueue.Enqueue(edge.Node);
                    }
                }
            }
        }
    }
}