namespace DijkstraOnMatrixes.Models
{
    public class MarkableNode : Node
    {
        public MarkableNode(int stepCost) : base(stepCost)
        {
            Visited = false;
            ReachCost = int.MaxValue;
        }

        public bool Visited { get; set; }
        public int ReachCost { get; set; }
    }
}
