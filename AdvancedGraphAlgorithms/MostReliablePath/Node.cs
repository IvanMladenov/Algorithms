namespace MostReliablePath
{
    using System;

    public class Node:IComparable
    {
        public Node(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public double Reliability { get; set; }

        public Node PrevNode { get; set; }

        public int CompareTo(object other)
        {
            return this.Reliability.CompareTo((other as Node).Reliability);
        }
    }
}