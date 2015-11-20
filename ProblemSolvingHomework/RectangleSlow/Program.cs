using System;
using System.Linq;

namespace RectangleSlow
{
    class Program
    {
        static byte[,] matrix = new byte[2001, 2001];

        static void Main()
        {
            int numberOfRectangles = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < numberOfRectangles; i++)
            {
                int[] currentRect =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                int startX = currentRect[0] + 1000;
                int endX = currentRect[1] + 1000;
                int startY = 1000 - currentRect[3];
                int endY = 1000 - currentRect[2];
                for (int x = startX; x < endX; x++)
                {
                    for (int y = startY; y < endY; y++)
                    {
                        if (matrix[x, y] == 1)
                        {
                            count++;
                        }

                        matrix[x, y]++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
