using System;
using System.Collections.Generic;
using DijkstraOnMatrixes.Models;

namespace DijkstraOnMatrixes.Interfaces
{
    public interface INeighbourFuncFactory
    {
        Func<int, int, IEnumerable<(int, int)>> CreateFunc(Directions directions, int sizeX, int sizeY);
    }
}
