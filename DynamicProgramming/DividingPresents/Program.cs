namespace DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] presents = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int presentsSum = presents.Sum();
            int target = presentsSum / 2;

            int[] alansPresents = DividePresents(presents, target);
            int alansPresentsSum = alansPresents.Sum();

            Console.WriteLine("Difference: {0}", Math.Abs(alansPresentsSum - (presentsSum-alansPresentsSum)));
            Console.WriteLine("Alan:{0} Bob:{1}", alansPresentsSum, presentsSum-alansPresentsSum);
            Console.WriteLine("Alan takes: {0}", alansPresents.Length > 0 ? string.Join(", ", alansPresents) : "None");
            Console.WriteLine("Bob takes the rest.");
        }

        private static int[] DividePresents(int[] presents, int target)
        {
            var matrix = new int[presents.Length, target + 1];
            var presentTaken = new bool[presents.Length, target + 1];

            for (int i = 0; i <= target; i++)
            {
                if (i >= presents[0])
                {
                    matrix[0, i] = presents[0];
                    presentTaken[0, i] = true;
                }
            }

            for (int i = 1; i < presents.Length; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                    int remainingSum = j - presents[i];

                    if (remainingSum >= 0 && matrix[i - 1, remainingSum] + presents[i] > matrix[i, j])
                    {
                        matrix[i, j] = matrix[i - 1, remainingSum] + presents[i];
                        presentTaken[i, j] = true;
                    }
                }
            }
            
            List<int> alansPresents = new List<int>(); 
            int currentPresent = presents.Length - 1;

            while (currentPresent>=0)
            {
                if (presentTaken[currentPresent, target])
                {
                    alansPresents.Add(presents[currentPresent]);
                    target -= presents[currentPresent];
                }

                currentPresent--;
            }

            return alansPresents.ToArray();
        }
    }
}
