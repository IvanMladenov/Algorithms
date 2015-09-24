namespace Problem_06_ConectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    internal class ProgramMain
    {
        private static readonly SortedSet<Area> foundedAreas = new SortedSet<Area>();

        private static readonly char[,] matrix =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
                { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' }
            };

        //private static readonly char[,] matrix =
        //    {
        //        { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
        //        { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
        //        { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },
        //        { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
        //        { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' }
        //    };

        private static readonly int RowsNum = matrix.GetLength(0);

        private static readonly int ColsNum = matrix.GetLength(1);

        private static void Main()
        {
            int?[] traversableCell = FindTraversableCell();

            while (traversableCell != null)
            {
                int row = traversableCell[0].Value;
                int col = traversableCell[1].Value;
                int[] startPosition = { row, col };
                Area currentArea = new Area(startPosition);
                FindConnectedCells(row, col, currentArea);
                foundedAreas.Add(currentArea);

                traversableCell = FindTraversableCell();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine("Total areas found: " + foundedAreas.Count);

            foreach (var area in foundedAreas)
            {
                Console.WriteLine(area);
            }
        }

        private static void FindConnectedCells(int row, int col, Area area)
        {
            if (row < 0 || col < 0 || row >= RowsNum || col >= ColsNum)
            {
                return;
            }

            if (matrix[row, col] == 'v' || matrix[row, col] == '*')
            {
                return;
            }

            matrix[row, col] = 'v';
            area.Size++;

            FindConnectedCells(row, col + 1, area);
            FindConnectedCells(row + 1, col, area);
            FindConnectedCells(row, col - 1, area);
            FindConnectedCells(row - 1, col, area);
        }

        private static int?[] FindTraversableCell()
        {
            int?[] traversableCell = new int?[2];
            for (int row = 0; row < RowsNum; row++)
            {
                for (int col = 0; col < ColsNum; col++)
                {
                    if (matrix[row, col] != 'v' && matrix[row, col] != '*')
                    {
                        traversableCell[0] = row;
                        traversableCell[1] = col;
                        return traversableCell;
                    }
                }
            }

            traversableCell = null;
            return traversableCell;
        }
    }
}