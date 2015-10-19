using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasInMatrix
{
    class Program
    {
        private static char[][] matrix;

        private static bool[,] visited;

        static void Main(string[] args)
        {
            int numberOfRows = 5;
            matrix = new char[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                string line = Console.ReadLine();
                matrix[i] = line.ToCharArray();
            }

            visited = new bool[matrix.Length, matrix[0].Length];
            SortedDictionary<char, int> result = new SortedDictionary<char, int>();
            int areasCounter = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row, col])
                    {
                        areasCounter++;
                        if (!result.ContainsKey(matrix[row][col]))
                        {
                            result.Add(matrix[row][col], 1);
                        }
                        else
                        {
                            result[matrix[row][col]]++;
                        }

                        FindConectedArea(row, col, matrix[row][col]);
                    }
                }
            }

            Console.WriteLine("Areas: {0}", areasCounter);
            foreach (var key in result.Keys)
            {
                Console.WriteLine("Letter '{0}' -> {1}", key, result[key]);
            }
        }

        private static void FindConectedArea(int row, int col, char current)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            if (visited[row, col]||matrix[row][col] != current)
            {
                return;
            }

            visited[row, col] = true;

            FindConectedArea(row, col+1, current);
            FindConectedArea(row+1, col, current);
            FindConectedArea(row, col-1, current);
            FindConectedArea(row-1, col, current);
        }

        private static bool IsInRange(int row, int col)
        {
            if (row < 0 || col < 0 || row > matrix.Length - 1 || col > matrix[row].Length - 1)
            {
                return false;
            }

            return true;
        }
    }
}
