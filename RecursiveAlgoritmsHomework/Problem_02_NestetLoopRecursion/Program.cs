namespace Problem_02_NestetLoopRecursion
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] combination = new int[n];

            GenerateCombinations(n, combination, 0);
        }

        private static void GenerateCombinations(int n, int[] combination, int index)
        {
            for (int i = 1; i <= n; i++)
            {
                combination[index] = i;
                if (index + 1 != n)
                {
                    GenerateCombinations(n, combination, index + 1);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", combination));
                }
            }
        }
    }
}