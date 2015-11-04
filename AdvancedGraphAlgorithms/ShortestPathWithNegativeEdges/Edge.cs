namespace ShortestPathWithNegativeEdges
{
    public class Edge
    {
        public Edge(int startNode, int endNode, double distance)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Distance = distance;
        }

        public double Distance { get; set; }

        public int EndNode { get; set; }

        public int StartNode { get; set; }
    }
}
