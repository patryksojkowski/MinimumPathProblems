using DijkstraOnMatrixes.Models;

namespace DijkstraOnMatrixes.Interfaces
{
    public interface INodeFactory
    {
        Node CreateNode(int stepCost);
        MarkableNode CreateMarkableNode(int stepCost);
    }
}
