using System;
using System.Collections.Generic;
using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes.Models
{
    public class MatrixNeighbourFuncFactory : INeighbourFuncFactory
    {
        public Func<int, int, IEnumerable<(int, int)>> CreateFunc(Directions directions, int sizeX, int sizeY)
        {
            var commands = new List<Action<int, int, List<(int, int)>>>();
            if ((directions & Directions.Down) == Directions.Down)
            {
                commands.Add((x, y, enumerable) =>
                {
                    if (y + 1 < sizeY)
                    {
                        enumerable.Add((x, y + 1));
                    }
                });
            }
            if ((directions & Directions.Up) == Directions.Up)
            {
                commands.Add((x, y, enumerable) =>
                {
                    if (y - 1 >= 0)
                    {
                        enumerable.Add((x, y - 1));
                    }
                });
            }
            if ((directions & Directions.Right) == Directions.Right)
            {
                commands.Add((x, y, enumerable) =>
                {
                    if (x + 1 < sizeX)
                    {
                        enumerable.Add((x + 1, y));
                    }
                });
            }
            if ((directions & Directions.Left) == Directions.Left)
            {
                commands.Add((x, y, enumerable) =>
                {
                    if (x - 1 >= 0)
                    {
                        enumerable.Add((x - 1, y));
                    }
                });
            }

            Func<int, int, IEnumerable<(int, int)>> resultFunc = (a, b) =>
            {
                var output = new List<(int, int)>();
                foreach (var command in commands)
                {
                    command(a, b, output);
                }
                return output;
            };
            return resultFunc;
        }
    }
}
