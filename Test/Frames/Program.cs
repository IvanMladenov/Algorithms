using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class Program
    {
        static SortedSet<string> output = new SortedSet<string>();
        static int[] indices;

        static void Main(string[] args)
        {
            int numberOfFrmes = int.Parse(Console.ReadLine());
            List<string> frames = new List<string>();

            for (int i = 0; i < numberOfFrmes; i++)
            {
                string line = Console.ReadLine();
                char[] arr = line.ToCharArray();
                Array.Reverse(arr);
                string reversedLine = new string(arr);
                frames.Add(line);
                if (line[0]!=line[2])
                {
                    frames.Add(reversedLine);
                }              
            }

            var combinations = GenerateCombinations(numberOfFrmes, frames.Count);
            foreach (var combination in combinations)
            {
                var current = new string[numberOfFrmes];
                for (int i = 0; i < combination.Length; i++)
                {
                    current[i] = frames[combination[i] - 1];
                }
                Permute(current, 0);
            }

            Console.WriteLine(output.Count);
            foreach (var str in output)
            {
                Console.WriteLine(str);
            }
        }

        static void Permute(string[] elements, int index)
        {
            if (index == elements.Length)
            {
                string basic = string.Join(" | ", elements);
                output.Add(basic);
                return;
            }

            Permute(elements, index + 1);
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(ref elements[i], ref elements[index]);
                Permute(elements, index + 1);
                Swap(ref elements[i], ref elements[index]);
            }
        }

        private static void Swap(ref string s, ref string s1)
        {
            string old = s;
            s = s1;
            s1 = old;
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

