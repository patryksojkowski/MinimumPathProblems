using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes.Models
{
    public class NodeFactory : INodeFactory
    {
        public Node CreateNode(int stepCost)
        {
            return new Node(stepCost);
        }

        public MarkableNode CreateMarkableNode(int stepCost)
        {
            return new MarkableNode(stepCost);
        }
    }
}
