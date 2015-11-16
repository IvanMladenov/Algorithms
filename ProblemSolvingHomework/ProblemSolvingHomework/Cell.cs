//using System;

//namespace ProblemSolvingHomework
//{
//    public class Cell:IComparable<Cell>
//    {
//        public Cell(int startX, int endX, int startY, int endY)
//        {
//            this.StartX = startX;
//            this.EndX = endX;
//            this.StartY = startY;
//            this.EndY = endY;
//        }

//        public int StartX { get; set; }

//        public int EndX { get; set; }

//        public int StartY { get; set; }

//        public int EndY { get; set; }

//        public int CompareTo(Cell other)
//        {
//            if (StartX == other.StartX && EndX == other.EndX)
//            {
//                if (StartY == other.StartY && EndY == other.EndY)
//                {
//                    return 0;
//                }
//            }

//            return -1;
//        }
//    }
//}
