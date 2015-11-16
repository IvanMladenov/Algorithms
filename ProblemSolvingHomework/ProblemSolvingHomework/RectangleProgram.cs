using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolvingHomework
{
    class RectangleProgram
    {
        static void Main(string[] args)
        {
            int numberOfRectangles = int.Parse(Console.ReadLine());

            HashSet<Cell> overlapped = new HashSet<Cell>();
            List<Cell> notOverlapped = new List<Cell>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                int[] currentRect =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                List<Cell> currentRectCells = GetRectangleCells(currentRect);
                for (int j=0; j<currentRectCells.Count; j++)
                {
                    Cell cell = currentRectCells[j];
                    bool added = false;
                    foreach (var single in notOverlapped)
                    {
                        if (single.CompareTo(cell)==0)
                        {
                            cell = single;
                            overlapped.Add(cell);
                            added = true;
                            break;
                        }
                    }

                    if (!added)
                    {
                        notOverlapped.Add(cell);
                    }
                    //if (notOverlapped.Contains(cell))
                    //{
                    //    overlapped.Add(cell);
                    //}
                    //else
                    //{
                    //    notOverlapped.Add(cell);
                    //}
                }
            }

            Console.WriteLine(overlapped.Count*100);
        }

        private static List<Cell> GetRectangleCells(int[] currentRect)
        {
            List<Cell> cells = new List<Cell>();

            for (int i = currentRect[0]; i <= currentRect[1]-10; i+=10)
            {
                int startX = i;
                int endX = i + 10;
                for (int j = currentRect[2]; j <=currentRect[3]-10; j+=10)
                {
                    int startY = j;
                    int endY = j + 10;
                    Cell cell = new Cell(startX, endX, startY, endY);
                    cells.Add(cell);
                }
            }

            return cells;
        }
    }

    public class Cell : IComparable<Cell>
    {
        public Cell(int startX, int endX, int startY, int endY)
        {
            this.StartX = startX;
            this.EndX = endX;
            this.StartY = startY;
            this.EndY = endY;
        }

        public int StartX { get; set; }

        public int EndX { get; set; }

        public int StartY { get; set; }

        public int EndY { get; set; }

        public int CompareTo(Cell other)
        {
            if (StartX == other.StartX && EndX == other.EndX)
            {
                if (StartY == other.StartY && EndY == other.EndY)
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}
