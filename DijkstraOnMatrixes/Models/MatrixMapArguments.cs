using DijkstraOnMatrixes.Models;
using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes
{
    public class MatrixMapArguments : IMatrixMapArguments
    {
        public MatrixMapArguments(string path, Directions directions)
        {
            Path = path;
            Directions = directions;
        }

        public string Path { get; }
        public Directions Directions { get; }
    }
}