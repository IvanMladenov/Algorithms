namespace Problem_02_IterativelyPermutations
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbersArray = Enumerable.Range(1, n).ToArray();
            var controlArray = Enumerable.Range(0, n + 1).ToArray();
            int index = 1;
            int j;
            int permutationCounter = 1;
            Console.WriteLine(string.Join(", ", numbersArray));

            while (index < n)
            {
                controlArray[index]--;
                j = index % 2 * controlArray[index];
                Swap(numbersArray, index, j);
                index = 1;

                while (controlArray[index] == 0)
                {
                    controlArray[index] = index;
                    index++;
                }

                permutationCounter++;
                Console.WriteLine(string.Join(", ", numbersArray));         
            }

            Console.WriteLine("Total permutations: " + permutationCounter);
        }

        private static void Swap(int[] numbersArray, int i, int j)
        {
            int temporary;
            temporary = numbersArray[j];
            numbersArray[j] = numbersArray[i];
            numbersArray[i] = temporary;
        }
    }
}