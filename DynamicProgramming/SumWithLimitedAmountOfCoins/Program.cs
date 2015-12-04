namespace SumWithLimitedAmountOfCoins
{
    using System;
    using System.Linq;

    class Program
    {

        private static int combinationsCount;
        private static bool[] usedCoins;

        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            string[] secondLine = Console.ReadLine().Split();
            int targetSum = int.Parse(firstLine[firstLine.Length - 1]);
            int[] coins = secondLine[secondLine.Length - 1]
                .Split(new[] { '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Array.Sort(coins);

            GeneratiCombinationsDynamic(coins, targetSum);

            //usedCoins = new bool[coins.Length];

            //for (int i = coins.Length - 1; i >= 0; i--)
            //{
            //    GeneratiCombinations(coins, targetSum, i);
            //}

            Console.WriteLine(combinationsCount);
        }

        private static void GeneratiCombinationsDynamic(int[] coins, int targetSum)
        {
            bool[,] memo = new bool[coins.Length + 1, targetSum + 1];

            for (int row = 1; row < memo.GetLength(0); row++)
            {
                for (int col = 1; col < memo.GetLength(1); col++)
                {
                    if (col - coins[row-1] == 0)
                    {
                        memo[row, col] = true;
                    }
                    else if (col - coins[row-1] > 0)
                    {
                        int remainder = col - coins[row-1];
                        if (memo[row - 1, remainder])
                        {
                            memo[row, col] = true;
                        }
                    }
                    else
                    {
                        memo[row, col] = memo[row - 1, col];
                    }
                }
            }

            for (int row = memo.GetLength(0)-1; row >= 0; row--)
            {
                if (memo[row, targetSum])
                {
                    combinationsCount++;
                }
            }
        }

        private static void GeneratiCombinations(int[] coins, int targetSum, int startIndex)
        {
            if (startIndex < 0)
            {
                return;
            }

            if (targetSum - coins[startIndex] == 0)
            {
                combinationsCount++;
            }
            else if (targetSum - coins[startIndex] < 0)
            {
                GeneratiCombinations(coins, targetSum, startIndex - 1);
            }
            else
            {
                GeneratiCombinations(coins, targetSum - coins[startIndex], startIndex - 1);
            }
        }
    }
}
