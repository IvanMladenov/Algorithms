using System;
using System.Linq;
using System.Numerics;

namespace Election
{
    internal class Program
    {
        private static BigInteger combinationsCount;

        private static void Main(string[] args)
        {
            var targetSum = int.Parse(Console.ReadLine());
            var numberOfParties = int.Parse(Console.ReadLine());

            var seats = new long[numberOfParties];
            for (var i = 0; i < numberOfParties; i++)
            {
                seats[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(seats);
            CountCombinationsDynamicaly(seats, targetSum);

            Console.WriteLine(combinationsCount);
        }

        private static void CountCombinationsDynamicaly(long[] seats, long targetSum)
        {
            BigInteger[] prev = new BigInteger[seats.Sum() + 1];
            long index = 0;
            long maxSum = 0;

            while (index < seats.Length)
            {
                maxSum += seats[index];
                BigInteger[] current = new BigInteger[seats.Sum() + 1];
                for (long i = 1; i <= maxSum; i++)
                {
                    if (i == seats[index])
                    {
                        current[i] = prev[i] + 1;
                    }
                    else if (i > seats[index])
                    {
                        var remainder = i - seats[index];
                        current[i] = prev[i] + prev[remainder];
                    }
                    else
                    {
                        current[i] = prev[i];
                    }
                }

                Array.Copy(current, prev, current.Length);
                index++;              
            }

            for (long i = targetSum; i < prev.Length; i++)
            {
                combinationsCount += prev[i];
            }
        }
    }
}