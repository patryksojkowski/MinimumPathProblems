using System;
using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes
{
    public class Problem81 : IProblem
    {
        private readonly IMatrixMap _map;
        private readonly IWalker _walker;

        public Problem81(IMatrixMap map, IWalker walker)
        {
            _map = map;
            _walker = walker;
        }

        public void Solve()
        {
            var result = _walker.ReachPosition(_map.SizeX - 1, _map.SizeY - 1, 0, 0);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}