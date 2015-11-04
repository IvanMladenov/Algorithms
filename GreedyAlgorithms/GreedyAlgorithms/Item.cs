namespace GreedyAlgorithms
{
    using System;

    public class Item : IComparable<Item>
    {
        public Item(int price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
            this.PricePerWeight = (double)this.Price / this.Weight;
        }

        private double PricePerWeight { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }

        public int CompareTo(Item other)
        {
            return this.PricePerWeight.CompareTo(other.PricePerWeight)*-1;
        }
    }
}