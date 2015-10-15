namespace SumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Linq;

    class Program
    {
        private static int combinationsCount;

        static void Main()
        {
            int targetSum = 6;
            int[] coins = { 1, 2, 3, 4, 6 };

            for (int i = coins.Length - 1; i >= 0; i--)
            {
                int currentIndex = i;

                GenerateCombinations(coins, currentIndex, targetSum);
            }

            Console.WriteLine(combinationsCount);
        }

        private static void GenerateCombinations(int[] coins, int currentIndex, int targetSum)
        {
            if (currentIndex < 0)
            {
                return;
            }

            int coinsCount = targetSum / coins[currentIndex];
            int remainder = targetSum % coins[currentIndex];

            if (remainder == 0)
            {
                combinationsCount++;
                while (true)
                {
                    if (coinsCount == 1)
                    {
                        break;
                    }
                    coinsCount--;
                    int newTarget = targetSum - coinsCount * coins[currentIndex];
                    for (int i = currentIndex - 1; i >= 0; i--)
                    {
                        GenerateCombinations(coins, i, newTarget);
                    }
                }
            }
            else
            {
                if (coinsCount > 0)
                {
                    int remainderAddition = 0;
                    while (coinsCount > 0)
                    {
                        for (int i = currentIndex - 1; i >= 0; i--)
                        {
                            GenerateCombinations(coins, i, remainder + remainderAddition);
                        }

                        coinsCount--;
                        remainderAddition += coins[currentIndex];
                    }
                }
            }
        }
    }
}
