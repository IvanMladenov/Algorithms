using System;

namespace DynamicProgramming
{
    internal class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var result = GetNumber(n, k);
            Console.WriteLine(result);
        }

        //public static int GetNumber(int x, int y)
        //{
        //    if ((x + 1) == 1 || (y + 1) == 1 || x == y)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return GetNumber(x - 1, y - 1) + GetNumber(x - 1, y);
        //    }
        //}

        //// Method using memoization, very fast
        public static int GetNumber(int x, int y)
        {
            var pyramid = new int[x + 1][];
            for (var i = 0; i < pyramid.Length; i++)
            {
                pyramid[i] = new int[i + 1];
                for (var j = 0; j < i + 1; j++)
                {
                    if (j == 0 || j == i)
                    {
                        pyramid[i][j] = 1;
                    }
                    else
                    {
                        pyramid[i][j] = pyramid[i - 1][j - 1] + pyramid[i - 1][j];
                    }
                }
            }

            return pyramid[x][y];
        }
    }
}