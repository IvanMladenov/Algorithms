namespace LabAlgorithms12November
{
    using System;
    using System.Runtime.InteropServices;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int numberOfBlocks = int.Parse(Console.ReadLine());
            int n = numberOfBlocks - 3;
            int combinations = n * (n + 1) * (n + 2) * (n + 3) / 4;
            Console.WriteLine("Number of blocks: {0}", combinations);
            char lastLetter = (char)('A' + numberOfBlocks);
            for (char first = 'A'; first < lastLetter - 3; first++)
            {
                for (char second = (char)(first + 1); second < lastLetter; second++)
                {
                    for (char third = (char)(second + 1); third < lastLetter; third++)
                    {
                        for (char fourth = (char)(third + 1); fourth < lastLetter; fourth++)
                        {
                            char[] currentTriple = { second, third, fourth };
                            PrintCurrentCombinations(first, currentTriple);
                        }
                    }
                }
            }
        }

        private static void PrintCurrentCombinations(char first, char[] currentTriple)
        {
            Console.WriteLine(first + new string(currentTriple));
            Array.Reverse(currentTriple);
            Console.WriteLine(first + new string(currentTriple));
            Swap(currentTriple);
            Console.WriteLine(first + new string(currentTriple));
            Array.Reverse(currentTriple);
            Console.WriteLine(first + new string(currentTriple));
            Swap(currentTriple);
            Console.WriteLine(first + new string(currentTriple));
            Array.Reverse(currentTriple);
            Console.WriteLine(first + new string(currentTriple));
        }

        private static void Swap(char[] currentTriple)
        {
            char first = currentTriple[0];
            currentTriple[0] = currentTriple[1];
            currentTriple[1] = first;
        }
    }
}