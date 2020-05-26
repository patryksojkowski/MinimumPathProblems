using System;
using System.Collections.Generic;
using DijkstraOnMatrixes.Models;

namespace DijkstraOnMatrixes.Interfaces
{
    public interface IMatrixMap
    {
        int SizeX { get; }

        int SizeY { get; }

        Node[,] Nodes { get; }

        Func<int, int, IEnumerable<(int, int)>> GetNeighboursOf { get; }
    }
}
