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

            // Take all overlaping areas as rectangles and put it to overlapRectangles List above.
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

            overlapRectangles = overlapRectangles.OrderByDescending(x => x.EndX).ToList();
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

        /// Method checks for overlaping area and return it as new Rectangle. In case of no such area returns null.
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
