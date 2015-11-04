namespace FloydWarshallShortestPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using ExtendCableNetwork;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] firstLine = Regex.Split(Console.ReadLine(), "[^\\d]+");
            int nodes = int.Parse(firstLine[1]);
            string[] secondLine = Regex.Split(Console.ReadLine(), "[^\\d]+");
            int edgesNumber = int.Parse(secondLine[1]);
            Edge[] edges = new Edge[edgesNumber];
            for (int i = 0; i < edgesNumber; i++)
            {
                int[] current = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var currentEdge = new Edge(current[0], current[1], current[2]);
                edges[i] = currentEdge;
            }

            int?[,] matrix = InitializeMatrix(nodes, edges);
            CalcDistances(matrix);
            Console.WriteLine("Shortest paths matrix:");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int?[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == null)
                    {
                        Console.Write("{0}", "0".PadLeft(3, ' '));
                    }
                    else
                    {
                        Console.Write("{0}", matrix[row, col].ToString().PadLeft(3, ' '));
                    }
                }

                Console.WriteLine();
            }
        }

        private static void CalcDistances(int?[,] matrix)
        {
            int numberOfIterations = matrix.GetLength(0);
            for (int i = 0; i < numberOfIterations; i++)
            {
                HashSet<int> blockedRows = new HashSet<int> { i };
                HashSet<int> blockedCols = new HashSet<int> { i };
                for (int j = 0; j < numberOfIterations; j++)
                {
                    if (matrix[i, j] == null)
                    {
                        blockedCols.Add(j);
                    }

                    if (matrix[j, i] == null)
                    {
                        blockedRows.Add(j);
                    }
                }

                for (int row = 0; row < numberOfIterations; row++)
                {
                    if (blockedRows.Contains(row))
                    {
                        continue;
                    }

                    for (int col = 0; col < numberOfIterations; col++)
                    {
                        if (blockedCols.Contains(col))
                        {
                            continue;
                        }

                        if (row != col)
                        {
                            int? newPath = matrix[i, col] + matrix[row, i];
                            if (matrix[row, col] > newPath || matrix[row, col] == null)
                            {
                                matrix[row, col] = newPath;
                            }
                        }
                    }
                }
                //PrintMatrix(matrix);
                //Console.WriteLine();
            }
        }

        private static int?[,] InitializeMatrix(int nodes, Edge[] edges)
        {
            int?[,] matrix = new int?[nodes, nodes];
            foreach (var edge in edges)
            {
                matrix[edge.StartNode, edge.EndNode] = edge.Weight;
                matrix[edge.EndNode, edge.StartNode] = edge.Weight;
            }

            return matrix;
        }
    }
}