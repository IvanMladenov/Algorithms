namespace Problem_04_GenerateSubsetsOfStringArray
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] set = {"test", "rock", "fun", "hey"};
            int k = 3;

            GenerateSubsets(set, k, new int[k], 0, 0);
        }

        private static void GenerateSubsets(string[] set, int k, int[] positions, int position, int startIndex)
        {
            if (position >= k)
            {
                foreach (var pos in positions)
                {
                    Console.Write(set[pos] + " ");
                }

                Console.WriteLine();
                return;
            }

            for (int i = startIndex; i < set.Length; i++)
            {
                positions[position] = i;
                GenerateSubsets(set, k, positions, position+1, i+1);
            }
        }
    }
}
