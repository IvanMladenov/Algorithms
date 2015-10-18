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

            Array.Sort(coins);

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
