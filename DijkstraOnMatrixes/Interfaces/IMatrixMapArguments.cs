using DijkstraOnMatrixes.Models;

namespace DijkstraOnMatrixes.Interfaces
{
    public interface IMatrixMapArguments
    {
        string Path { get; }
        Directions Directions { get; }
    }
}
