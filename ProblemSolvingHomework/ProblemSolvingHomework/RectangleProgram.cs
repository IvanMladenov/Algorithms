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
            Rectangle[] allRect = new Rectangle[numberOfRectangles];
            for (int i = 0; i < numberOfRectangles; i++)
            {
                int[] currentRect =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                Rectangle rect = new Rectangle(currentRect[0], currentRect[1], currentRect[2], currentRect[3]);
                allRect[i] = rect;
            }

            allRect = allRect.OrderBy(x => x.StartX).ToArray();
            List<Rectangle> overlapRectangles = new List<Rectangle>();
            for (int i = 0; i < allRect.Length - 1; i++)
            {
                for (int j = i + 1; j < allRect.Length; j++)
                {
                    Rectangle overlap = GetOverlapingRectangle(allRect[i], allRect[j]);
                    if (overlap!=null)
                    {
                        overlapRectangles.Add(overlap);
                    }
                }
            }

            bool[] reduced = new bool[overlapRectangles.Count];
            for (int i = 0; i < overlapRectangles.Count; i++)
            {
                for (int j = i+1; j < overlapRectangles.Count; j++)
                {
                    Rectangle overlap = GetOverlapingRectangle(overlapRectangles[i], overlapRectangles[j]);
                    if (overlap != null)
                    {
                        if (!reduced[i])
                        {
                            overlapRectangles[i].Area -= overlap.Area;
                            reduced[i] = true;
                        }
                    }
                }
            }

            var sum = overlapRectangles.Sum(x => x.Area);
            Console.WriteLine(sum);

        }

        private static Rectangle GetOverlapingRectangle(Rectangle first, Rectangle second)
        {
            if (second.StartX<first.EndX&&second.StartX>=first.StartX)
            {
                int startX = second.StartX;
                int endX = first.EndX;
                if (second.EndX < first.EndX)
                {
                    endX = second.EndX;
                }
                if (second.StartY >= first.StartY && second.StartY < first.EndY)
                {
                    int startY = second.StartY;
                    int endY = first.EndY;
                    if (second.EndY<first.EndY)
                    {
                        endY = second.EndY;
                    }

                    return new Rectangle(startX, endX, startY, endY);
                }
                else if (second.EndY<=first.EndY&&second.EndY>first.StartY)
                {
                    int endY = second.EndY;
                    int startY = first.StartY;
                    if (second.StartY>first.StartY)
                    {
                        startY = second.StartY;
                    }

                    return new Rectangle(startX, endX, startY, endY);
                }
                else if (second.EndY>=first.EndY&&second.StartY<=first.StartY)
                {
                    return new Rectangle(startX, endX, first.StartY, first.EndY);
                }
            }

            return null;
        }

        //        HashSet<Cell> overlapped = new HashSet<Cell>();
            //        List<Cell> notOverlapped = new List<Cell>();

            //        for (int i = 0; i < numberOfRectangles; i++)
            //        {
            //            int[] currentRect =
            //                Console.ReadLine()
            //                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //                    .Select(int.Parse)
            //                    .ToArray();
            //            List<Cell> currentRectCells = GetRectangleCells(currentRect);
            //            for (int j = 0; j < currentRectCells.Count; j++)
            //            {
            //                Cell cell = currentRectCells[j];
            //                bool added = false;
            //                foreach (var single in notOverlapped)
            //                {
            //                    if (single.CompareTo(cell) == 0)
            //                    {
            //                        cell = single;
            //                        overlapped.Add(cell);
            //                        added = true;
            //                        break;
            //                    }
            //                }

            //                if (!added)
            //                {
            //                    notOverlapped.Add(cell);
            //                }
            //                //if (notOverlapped.Contains(cell))
            //                //{
            //                //    overlapped.Add(cell);
            //                //}
            //                //else
            //                //{
            //                //    notOverlapped.Add(cell);
            //                //}
            //            }
            //        }

            //        Console.WriteLine(overlapped.Count * 100);
            //    }

            //    private static List<Cell> GetRectangleCells(int[] currentRect)
            //    {
            //        List<Cell> cells = new List<Cell>();

            //        for (int i = currentRect[0]; i <= currentRect[1] - 10; i += 10)
            //        {
            //            int startX = i;
            //            int endX = i + 10;
            //            for (int j = currentRect[2]; j <= currentRect[3] - 10; j += 10)
            //            {
            //                int startY = j;
            //                int endY = j + 10;
            //                Cell cell = new Cell(startX, endX, startY, endY);
            //                cells.Add(cell);
            //            }
            //        }

            //        return cells;
            //    }
            //}

            //public struct Cell : IComparable<Cell>
            //{
            //    public Cell(int startX, int endX, int startY, int endY)
            //    {
            //        this.StartX = startX;
            //        this.EndX = endX;
            //        this.StartY = startY;
            //        this.EndY = endY;
            //    }

            //    public int StartX { get; set; }

            //    public int EndX { get; set; }

            //    public int StartY { get; set; }

            //    public int EndY { get; set; }

            //    public int CompareTo(Cell other)
            //    {
            //        if (StartX == other.StartX && EndX == other.EndX)
            //        {
            //            if (StartY == other.StartY && EndY == other.EndY)
            //            {
            //                return 0;
            //            }
            //        }

            //        return -1;
                

        
    }

    public class Rectangle
    {
        public Rectangle(int startX, int endX, int startY, int endY)
        {
            this.StartX = startX;
            this.EndX = endX;
            this.StartY = startY;
            this.EndY = endY;
            Area = Math.Abs((startX - endX)*(StartY - endY));
        }

        public int StartX { get; set; }

        public int EndX { get; set; }

        public int StartY { get; set; }

        public int EndY { get; set; }

        public int Area { get; set; }
    }
}
