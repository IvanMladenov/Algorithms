namespace ZigZagMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfCols = int.Parse(Console.ReadLine());

            Cell[][] cellMatrix = new Cell[numberOfCols][];
            for (int i = 0; i < numberOfCols; i++)
            {
                cellMatrix[i] = new Cell[numberOfRows];
            }

            FillTheMatrices(numberOfRows, numberOfCols, cellMatrix);

            for (int i = 1; i < cellMatrix.Length; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = 0; j < cellMatrix[i].Length - 1; j++)
                    {
                        for (int k = j + 1; k < cellMatrix[i].Length; k++)
                        {
                            if (cellMatrix[i][j].Value + cellMatrix[i - 1][k].Max > cellMatrix[i][j].Max)
                            {
                                cellMatrix[i][j].Max = cellMatrix[i][j].Value + cellMatrix[i - 1][k].Max;
                                cellMatrix[i][j].Previous = k;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = cellMatrix[i].Length - 1; j >= 1; j--)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (cellMatrix[i][j].Value + cellMatrix[i - 1][k].Max > cellMatrix[i][j].Max)
                            {
                                cellMatrix[i][j].Max = cellMatrix[i][j].Value + cellMatrix[i - 1][k].Max;
                                cellMatrix[i][j].Previous = k;
                            }
                        }
                    }
                }
            }

            Cell maxCell = cellMatrix[cellMatrix.Length - 1].Max();
            int prev = maxCell.Previous;
            List<int> numbers = new List<int>();
            numbers.Add(maxCell.Value);
            for (int i = cellMatrix.Length - 2; i >= 0; i--)
            {
                Cell current = cellMatrix[i][prev];
                numbers.Add(current.Value);
                prev = current.Previous;
            }

            numbers.Reverse();
            Console.WriteLine("{0} = {1}", numbers.Sum(), string.Join(" + ", numbers));
        }

        private static void FillTheMatrices(int numberOfRows, int numberOfCols, Cell[][] cellMatrix)
        {
            for (int j = 0; j < numberOfRows; j++)
            {
                int[] currRow =
                    Console.ReadLine()
                        .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                for (int i = 0; i < numberOfCols; i++)
                {
                    cellMatrix[i][j] = new Cell(currRow[i]);
                    cellMatrix[i][j].Value = currRow[i];
                }
            }
        }
    }

    internal class Cell : IComparable<Cell>
    {
        public Cell(int max)
        {
            this.Max = max;
            this.Previous = -1;
        }

        public int Previous { get; set; }

        public int Max { get; set; }

        public int Value { get; set; }

        public int CompareTo(Cell other)
        {
            return this.Max.CompareTo(other.Max);
        }
    }
}