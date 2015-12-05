using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Portals
{
    class Program
    {
        static bool[,] visited;
        static int maxSum;

        static void Main(string[] args)
        {
            int[] startPositon = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];
            visited = new bool[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentLine = Regex.Replace(Console.ReadLine(), " ", string.Empty);
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (currentLine[col]!=35)
                    {
                        matrix[row, col] = currentLine[col] - 48;
                    }
                    else
                    {
                        matrix[row, col] = 35;
                    }
                    
                }
            }

            GetMaxSum(matrix, startPositon[0], startPositon[1], 0);

            Console.WriteLine(maxSum);
        }

        private static void GetMaxSum(int[,] matrix, int row, int col, int currentMax)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                if (currentMax > maxSum)
                {
                    maxSum = currentMax;
                }
                return;
            }
            if (visited[row, col] || matrix[row, col] == 35)
            {
                if (currentMax > maxSum)
                {
                    maxSum = currentMax;
                }
                return;
            }

            currentMax += matrix[row, col];
            visited[row, col] = true;
            GetMaxSum(matrix, row, col + matrix[row, col], currentMax);//right
            GetMaxSum(matrix, row + matrix[row, col], col, currentMax);//down
            GetMaxSum(matrix, row, col - matrix[row, col], currentMax);//left
            GetMaxSum(matrix, row - matrix[row, col], col, currentMax);//up
        }
    }
}
