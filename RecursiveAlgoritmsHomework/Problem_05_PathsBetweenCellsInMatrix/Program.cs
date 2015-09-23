namespace Problem_05_PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    internal class Program
    {
        private static readonly char[,] matrix =
            {
                { 's', ' ', ' ', ' ' },
                { ' ', '*', '*', ' ' }, 
                { ' ', '*', '*', ' ' },
                { ' ', '*', 'e', ' ' }, 
                { ' ', ' ', ' ', ' ' }
            };

        private static readonly int numRows = matrix.GetLength(0);

        private static readonly int numCols = matrix.GetLength(1);

        private static int pathsCounter = 0;

        static List<char> pathToExit = new List<char>(); 

        private static void Main()
        {
            int[] startCell = FindStart();
            FindExit(startCell[0], startCell[1], '\0');
            Console.WriteLine("Total paths found: " + pathsCounter);
        }

        private static int[] FindStart()
        {
            int[] sCell = new int[2];

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        sCell[0] = row;
                        sCell[1] = col;
                        return sCell;
                    }
                }
            }

            return sCell;
        }

        private static void FindExit(int row, int col, char direction)
        {
            if (row < 0 || col < 0 || row >= numRows || col >= numCols)
            {
                return;
            }

            if (matrix[row, col] == 'v' || matrix[row, col] == '*')
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                string textPath = string.Join("", pathToExit.GetRange(1, pathToExit.Count - 1));
                Console.WriteLine(textPath+direction);
                //PrintMatrix();
                pathsCounter++;
                return;
            }

            matrix[row, col] = 'v';
            pathToExit.Add(direction);

            FindExit(row, col + 1, 'R'); //Right
            FindExit(row, col - 1, 'L'); //Left
            FindExit(row + 1, col, 'D'); //Down
            FindExit(row - 1, col, 'U'); //Up

            matrix[row, col] = ' ';
            pathToExit.RemoveAt(pathToExit.Count-1);
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}