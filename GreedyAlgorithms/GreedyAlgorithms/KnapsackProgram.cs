namespace GreedyAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class KnapsackProgram
    {
        private static void Main(string[] args)
        {
            int capacity = int.Parse(Regex.Match(Console.ReadLine(), "[\\d]+").ToString());
            int numberOfItems = int.Parse(Regex.Match(Console.ReadLine(), "[\\d]+").ToString());
            List<Item> items = new List<Item>();

            for (int i = 0; i < numberOfItems; i++)
            {
                string[] line = Regex.Split(Console.ReadLine(), "[^\\d]+");
                Item current = new Item(int.Parse(line[0]), int.Parse(line[1]));
                items.Add(current);
            }

            items.Sort();
            double totalPrice = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Weight > capacity)
                {
                    double percentCanTake = (capacity * 100) / (double)items[i].Weight;
                    double priesForThePart = (percentCanTake*items[i].Price)/(double)100;
                    totalPrice += priesForThePart;
                    Console.WriteLine("Take {2:F2}% of item with price {0:F2} and weight {1:F2}",
                        items[i].Price,
                        items[i].Weight,
                        percentCanTake);
                    break;
                }

                capacity -= items[i].Weight;
                totalPrice += items[i].Price;
                Console.WriteLine("Take 100% of item with price {0:F2} and weight {1:F2}", items[i].Price, items[i].Weight);
            }

            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }
    }
}