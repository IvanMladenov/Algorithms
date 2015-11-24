using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridges
{
    class Program
    {
        static void Main()
        {
            int[] north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] south = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Bridge> bridges = new List<Bridge>();
            for (int i = 0; i < north.Length; i++)
            {
                for (int j = 0; j < south.Length; j++)
                {
                    if (north[i] == south[j])
                    {
                        bridges.Add(new Bridge(i, j));
                    }
                }
            }

            while (bridges.Count > 0)
            {
                UpdateCrossings(bridges);
                bridges.Sort((a, b) => a.Crossings.CompareTo(b.Crossings));
                if (bridges[bridges.Count - 1].Crossings == 0)
                {
                    break;
                }

                bridges.RemoveAt(bridges.Count - 1);
            }

            Console.WriteLine(bridges.Count);
        }

        private static void UpdateCrossings(List<Bridge> bridges)
        {
            for (int i = 0; i < bridges.Count; i++)
            {
                bridges[i].Crossings = 0;
                for (int j = 0; j < bridges.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (bridges[i].North < bridges[j].North && bridges[i].South > bridges[j].South)
                    {
                        bridges[i].Crossings++;
                    }

                    if (bridges[i].North > bridges[j].North && bridges[i].South < bridges[j].South)
                    {
                        bridges[i].Crossings++;
                    }
                }
            }
        }
    }

    class Bridge
    {
        public Bridge(int north, int south)
        {
            this.South = south;
            this.North = north;
        }

        public int North { get; set; }

        public int South { get; set; }

        public int Crossings { get; set; }
    }
}
