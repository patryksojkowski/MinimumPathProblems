namespace DijkstraOnMatrixes.Models
{
    public class Node
    {
        public Node(int stepCost)
        {
            StepCost = stepCost;
        }
        public int StepCost { get; }
    }
}
