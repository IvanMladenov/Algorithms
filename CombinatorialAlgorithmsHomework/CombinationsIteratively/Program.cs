namespace CombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            foreach (var combination in GenerateCombinations(n, m))
            {
                for (int i = 0; i < combination.Length; i++)
                {
                    Console.Write(combination[i] + " ");
                }

                Console.WriteLine();
            }
        }

        private static IEnumerable<int[]> GenerateCombinations(int combinationNumbersCount, int numbersCount)
        {
            int[] result = new int[combinationNumbersCount];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= numbersCount)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == combinationNumbersCount)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}