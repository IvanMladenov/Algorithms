namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using ExtendCableNetwork;

    internal class Program
    {
        private static void Main()
        {
            string[] proba = Regex.Split(Console.ReadLine(), "[^\\d]+");
            int nodesNumber = int.Parse(proba[1]);
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < nodesNumber; i++)
            {
                int[] currentEdge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var edge = new Edge(currentEdge[0], currentEdge[1], currentEdge[2]);
                edges.Add(edge);
            }

            var minimumSpaningForest = Kruskal(edges, nodesNumber);
            Console.WriteLine("Minimum spanning forest weight: {0}",
                minimumSpaningForest.Sum(x=>x.Weight));
            foreach (var edge in minimumSpaningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> Kruskal(List<Edge> edges, int nodesNumber)
        {
            edges.Sort();

            var tree = new List<Edge>();
            var parent = new int[nodesNumber];
            for (int i = 0; i < nodesNumber; i++)
            {
                parent[i] = i;
            }

            foreach (var edge in edges)
            {
                var rootStarNode = Root(edge.StartNode, parent);
                var rootEndNode = Root(edge.EndNode, parent);
                if (rootEndNode!=rootStarNode)
                {
                    tree.Add(edge);
                    parent[rootStarNode] = rootEndNode;
                }
            }

            return tree;
        }

        private static int Root(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}