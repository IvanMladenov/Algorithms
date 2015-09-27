namespace Problem_01_TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int stepsCount;

        private static Stack<int> source;

        private static readonly Stack<int> destination = new Stack<int>();

        private static readonly Stack<int> spare = new Stack<int>();

        private static void Main()
        {
            int numberOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            PrintRods();
            MoveDisks(numberOfDisks, source, destination, spare);
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsCount++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk: {1}", stepsCount, bottomDisk);
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                stepsCount++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk: {1}", stepsCount, bottomDisk);
                PrintRods();
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
    }
}