using System;

namespace LineInverter
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[,] matrix = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j] == 'W';
                }
            }

            for (int i = 0; i <= n; i++)
            {
                int[] bestRow = FindBestRow(matrix);
                int[] bestCol = FindBestCol(matrix);
                if (bestCol[0] == -1 && bestRow[0] == -1)
                {
                    Console.WriteLine(i);
                    return;
                }

                if (bestRow[1]>bestCol[1])
                {
                    InvertRow(matrix, bestRow[0]);
                }
                else
                {
                    InvertCol(matrix, bestCol[0]);
                }
            }

            Console.WriteLine(-1);
        }

        private static void InvertCol(bool[,] matrix, int bestCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, bestCol] = !matrix[row, bestCol];
            }
        }

        private static void InvertRow(bool[,] matrix, int bestRow)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[bestRow, col] = !matrix[bestRow, col];
            }
        }

        private static int[] FindBestCol(bool[,] matrix)
        {
            int index = -1;
            int bestCol = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int numberOfWhite = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col])
                    {
                        numberOfWhite++;
                    }
                }

                if (numberOfWhite > bestCol)
                {
                    bestCol = numberOfWhite;
                    index = col;
                }
            }

            return new []{index, bestCol};
        }

        private static int[] FindBestRow(bool[,] matrix)
        {
            int index = -1;
            int bestRow = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int numberOfWhite = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col])
                    {
                        numberOfWhite++;
                    }
                }

                if (numberOfWhite > bestRow)
                {
                    bestRow = numberOfWhite;
                    index = row;
                }
            }

            return new []{index, bestRow};
        }
    }
}
