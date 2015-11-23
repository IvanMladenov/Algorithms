using System;
using System.Collections.Generic;

namespace GroupPermutations
{
    class Program
    {
        static void Main()
        {
            char[] inputLine = Console.ReadLine().ToCharArray();

            int startIndex = 0;
            List<string> groupedChars = new List<string>();
            Array.Sort(inputLine);
            char prev = inputLine[0];
            for (int i = 1; i < inputLine.Length; i++)
            {
                if (inputLine[i]!=prev)
                {
                    string current = new string(prev, i-startIndex);
                    groupedChars.Add(current);
                    prev = inputLine[i];
                    startIndex = i;
                }

                if (i == inputLine.Length-1)
                {
                    string current = new string(prev, i-startIndex+1);
                    groupedChars.Add(current);
                }
            }

            Permute(groupedChars.ToArray(), 0);
        }

        static void Permute(string[] elements, int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Concat(elements));
                return;
            }

            Permute(elements, index + 1);
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(ref elements[i], ref elements[index]);
                Permute(elements, index+1);
                Swap(ref elements[i], ref elements[index]);
            }
        }

        private static void Swap(ref string s, ref string s1)
        {
            string old = s;
            s = s1;
            s1 = old;
        }
    }
}
