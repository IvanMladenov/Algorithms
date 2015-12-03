namespace SumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Linq;

    class Program
    {
        private static int combinationsCount;

        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            string[] secondLine = Console.ReadLine().Split();
            int targetSum = int.Parse(firstLine[firstLine.Length - 1]);
            int[] coins = secondLine[secondLine.Length - 1]
                .Split(new[] { '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            //Array.Sort(coins);

            //for (int i = coins.Length - 1; i >= 0; i--)
            //{
            //    int currentIndex = i;

            //    GenerateCombinations(coins, currentIndex, targetSum);
            //}

            GeneratCombinations(targetSum, coins);

            Console.WriteLine(combinationsCount);
        }

        private static void GeneratCombinations(int targetSum, int[] coins)
        {
            int[,] memo = new int[coins.Length+1, targetSum + 1];

            for (int row = 1; row < memo.GetLength(0); row++)
            {
                for (int col = 1; col < memo.GetLength(1); col++)
                {
                    if (coins[row-1] == col)
                    {
                        memo[row, col] = memo[row - 1, col] + 1;
                    }
                    else if (coins[row-1]<col)
                    {
                        memo[row, col] = memo[row - 1, col] + memo[row, col - coins[row-1]];
                    }
                    else
                    {
                        memo[row, col] = memo[row - 1, col];
                    }
                }
            }

            combinationsCount = memo[coins.Length, targetSum];
        }

        ////private static void GenerateCombinations(int[] coins, int currentIndex, int targetSum)
        ////{
        ////    if (currentIndex < 0)
        ////    {
        ////        return;
        ////    }

        ////    int coinsCount = targetSum / coins[currentIndex];
        ////    int remainder = targetSum % coins[currentIndex];

        ////    if (remainder == 0)
        ////    {
        ////        combinationsCount++;
        ////        while (true)
        ////        {
        ////            if (coinsCount == 1)
        ////            {
        ////                break;
        ////            }
        ////            coinsCount--;
        ////            int newTarget = targetSum - coinsCount * coins[currentIndex];
        ////            for (int i = currentIndex - 1; i >= 0; i--)
        ////            {
        ////                GenerateCombinations(coins, i, newTarget);
        ////            }
        ////        }
        ////    }
        ////    else
        ////    {
        ////        if (coinsCount > 0)
        ////        {
        ////            int remainderAddition = 0;
        ////            while (coinsCount > 0)
        ////            {
        ////                for (int i = currentIndex - 1; i >= 0; i--)
        ////                {
        ////                    GenerateCombinations(coins, i, remainder + remainderAddition);
        ////                }

        ////                coinsCount--;
        ////                remainderAddition += coins[currentIndex];
        ////            }
        ////        }
        ////    }
        ////}
    }
}
