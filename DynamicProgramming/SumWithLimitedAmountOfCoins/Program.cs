namespace SumWithLimitedAmountOfCoins
{
    using System;
    using System.Linq;

    class Program
    {

        private static int combinationsCount;
        private static bool[] usedCoins;

        // Not working correct for some sets of coins. It can be fixed by adding indices in list 
        // and then when find valid combination to add list in hashSet but it will slow up the programe
        // and I dont wont to implement it.
        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            string[] secondLine = Console.ReadLine().Split();
            int targetSum = int.Parse(firstLine[firstLine.Length-1]);
            int[] coins = secondLine[secondLine.Length-1]
                .Split(new []{'{', '}', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Array.Sort(coins);

            usedCoins = new bool[coins.Length];
            //GenerateCombinatioins(coins, coins.Length - 1, targetSum);
            //for (int i = coins.Length - 2; i >= 0; i--)
            //{
            //    if (coins[i] != coins[i + 1])
            //    {
            //        usedCoins = new bool[coins.Length];
            //        int currentIndex = i;
            //        GenerateCombinatioins(coins, currentIndex, targetSum);
            //    }
            //}
            GenerateCombinatioins(coins, 0, targetSum);
            for (int i = 1; i < coins.Length ; i++)
            {
                if (coins[i] != coins[i - 1])
                {
                    usedCoins = new bool[coins.Length];
                    int currentIndex = i;
                    GenerateCombinatioins(coins, currentIndex, targetSum);
                }
            }

            Console.WriteLine(combinationsCount);
        }

        private static void GenerateCombinatioins(int[] coins, int currentIndex, int targetSum)
        {
            if (currentIndex >= coins.Length)
            {
                return;
            }

            int diff = targetSum - coins[currentIndex];
            if (diff == 0)
            {
                usedCoins[currentIndex] = true;
                combinationsCount++;
            }
            else if (diff > 0)
            {
                for (int i = currentIndex + 1; i < coins.Length; i++)
                {
                    if (!usedCoins[i])
                    {
                        usedCoins[i] = true;
                        GenerateCombinatioins(coins, i, diff);
                    }
                }

            }
        }
    }
}
