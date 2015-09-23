using System;

namespace Problem_03_CombinationsWithRepetition
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int start = 1;
            int[] combination = new int[k];

            GenerateCombinations(combination, n, k, start);
        }

        private static void GenerateCombinations(int[] combination, int end, int k, int start)
        {
            int index = combination.Length - k;
            for (int i = start; i <= end; i++)
            {
                combination[index] = i;
                if (k == 1)
                {
                    Console.WriteLine(string.Join(" ", combination));
                }
                else
                {
                    GenerateCombinations(combination, end, k - 1, i+1);
                }
            }
        }
    }
}
