using System;
using System.Linq;

namespace BridgesDynamic
{
    internal class Program
    {
        static int[,] maxBridges;
        static int[] north;
        static int[] south;

        private static void Main()
        {
            north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            south = Console.ReadLine().Split().Select(int.Parse).ToArray();

            maxBridges = new int[north.Length, south.Length];
            for (int i = 0; i < north.Length; i++)
            {
                for (int j = 0; j < south.Length; j++)
                {
                    maxBridges[i, j] = -1;
                }
            }

            int result = CalcMaxBridges(north.Length - 1, south.Length - 1);
            Console.WriteLine(result);
        }

        private static int CalcMaxBridges(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (maxBridges[x, y] != -1)
            {
                return maxBridges[x, y];
            }

            int northLeft = CalcMaxBridges(x - 1, y);
            int southLeft = CalcMaxBridges(x, y - 1);

            if (north[x] == south[y])
            {
                maxBridges[x, y] = 1 + Math.Max(northLeft, southLeft);
            }
            else
            {
                maxBridges[x, y] = Math.Max(southLeft, northLeft);
            }

            return maxBridges[x, y];
        }
    }
}