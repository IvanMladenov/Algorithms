using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TreesAndTreeLikeStructures
{

    class Program
    {

        static void Main(string[] args)
        {
            int numberOfEdges = int.Parse(Console.ReadLine());

            HashSet<int> parents = new HashSet<int>();
            HashSet<int> childrens = new HashSet<int>();
            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] current = Console.ReadLine().Split();
                parents.Add(int.Parse(current[0]));
                childrens.Add(int.Parse(current[1]));
            }

            IEnumerable<int> result = parents.Intersect(childrens);
            foreach (var item in result)
            {
                childrens.Remove(item);
            }

            int[] forPrint = childrens.ToArray();
            Array.Sort(forPrint);

            Console.WriteLine(string.Join("\n", forPrint));
        }
    }
}
