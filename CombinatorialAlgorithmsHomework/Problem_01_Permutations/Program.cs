namespace Problem_01_Permutations
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int permutationsCount;

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbersArray = Enumerable.Range(1, n).ToArray();
            Permute(numbersArray);
            Console.WriteLine("Total permutations: " + permutationsCount);
        }

        private static void Permute(int[] numbersArray, int startIndex = 0)
        {
            if (startIndex == numbersArray.Length - 1)
            {
                Console.WriteLine(string.Join(", ", numbersArray));
                permutationsCount++;
            }
            else
            {
                for (int i = startIndex; i < numbersArray.Length; i++)
                {
                    if (startIndex != i)
                    {
                        Swap(ref numbersArray[startIndex], ref numbersArray[i]);
                    }
        
                    Permute(numbersArray, startIndex + 1);
                    if (startIndex != i)
                    {
                        Swap(ref numbersArray[i], ref numbersArray[startIndex]);
                    }
                }
            }
        }

        private static void Swap(ref int startIndex, ref int i)
        {
            startIndex ^= i;
            i ^= startIndex;
            startIndex ^= i;
        }
    }
}