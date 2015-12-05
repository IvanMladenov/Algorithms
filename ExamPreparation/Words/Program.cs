using System;
using System.Collections.Generic;
using System.Linq;

namespace Words
{
    internal class Program
    {
        private static HashSet<string> output = new HashSet<string>();

        static int total;

        private static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var arr = word.ToCharArray();

            HashSet<char> uniquesimbols = new HashSet<char>();
            for (int i = 0; i < arr.Length; i++)
            {
                uniquesimbols.Add(arr[i]);
            }

            //if (arr.Length == uniquesimbols.Count && arr.Length == 10)
            //{
            //    Console.WriteLine(3628800);
            //    return;
            //}

            //if (arr.Length>1&&uniquesimbols.Count==1)
            //{
            //    Console.WriteLine(0);
            //}
            //PermutationsRep(arr.ToList());
            //Array.Sort(arr);
            
            Permute(arr, 0);
            //Console.WriteLine(output.Count);
            Console.WriteLine(total);
        }

        private static void Permute(char[] elements, int index)
        {
            if (index == elements.Length)
            {
                char prev = elements[0];
                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i] == prev)
                    {
                        return;
                    }

                    prev = elements[i];
                }

                total++;
                Console.WriteLine(new string(elements));
               //output.Add(new string(elements));
                return;
            }

            Permute(elements, index + 1);
            for (var i = index + 1; i < elements.Length; i++)
            {
                if (elements[i]!=elements[index])
                {
                    Swap(ref elements[i], ref elements[index]);
                    Permute(elements, index + 1);
                    Swap(ref elements[i], ref elements[index]);
                }
            }
        }

        private static void Swap(ref char s, ref char s1)
        {
            var old = s;
            s = s1;
            s1 = old;
        }

        public static void PermutationsRep(List<char> permutations)
        {
            permutations.Sort();
            PermuteRep(permutations, 0, permutations.Count);
        }

        public static void PermuteRep(List<char> permutations, int start, int n)
        {
            var validCombination = true;
            for (int i = 0; i < permutations.Count - 1; i++)
            {
                if (permutations[i] == permutations[i + 1])
                {
                    validCombination = false;
                    break;
                }
            }

            if (validCombination)
            {
                total++;
            }

            //Console.WriteLine(String.Join("", permutations));

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    char swap;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (permutations[i] != permutations[j])
                        {
                            swap = permutations[i];
                            permutations[i] = permutations[j];
                            permutations[j] = swap;

                            PermuteRep(permutations, i + 1, n);
                        }
                    }

                    swap = permutations[i];
                    for (int k = i; k < n - 1;)
                    {
                        permutations[k] = permutations[++k];
                    }

                    permutations[n - 1] = swap;
                }
            }
        }
    }
}