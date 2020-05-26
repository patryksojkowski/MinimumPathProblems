using System;
using System.Collections.Generic;
using System.Linq;
using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes.Models
{
    class MapWalker : IWalker
    {
        private readonly IMatrixMap _map;
        private readonly INodeFactory _nodeFactory;
        private (int X, int Y) _position;
        public MapWalker(IMatrixMap map, INodeFactory nodeFactory) : this(map, nodeFactory, 0, 0)
        {

        }

        private MapWalker(IMatrixMap map, INodeFactory nodeFactory, int startX = 0, int startY = 0)
        {
            _map = map;
            this._nodeFactory = nodeFactory;
            CreateLocalNodes(map);

            _position = (startX, startY);
        }

        private MarkableNode[,] Nodes;

        private void CreateLocalNodes(IMatrixMap map)
        {
            Nodes = new MarkableNode[map.SizeX, map.SizeY];
            for (var i = 0; i < map.SizeX; i++)
            {
                for (var j = 0; j < map.SizeY; j++)
                {
                    var cost = map.Nodes[i, j].StepCost;
                    Nodes[i, j] = _nodeFactory.CreateMarkableNode(cost);
                }
            }
        }

        public int ReachPosition(int x, int y)
        {
            var startNode = Nodes[_position.X, _position.Y];
            startNode.ReachCost = startNode.StepCost;

            while (_position != (x, y))
            {
                Step();
            }
            return Nodes[x, y].ReachCost;

            void Step()
            {
                var currentNode = Nodes[_position.X, _position.Y];
                var currentCost = currentNode.ReachCost;
                currentNode.Visited = true;

                var neighboursCoordinates = _map.GetNeighboursOf(_position.X, _position.Y);
                UpdateNeighbours(neighboursCoordinates, currentCost);

                if (TryGetMinimumCostPosition(out var minPosition))
                {
                    _position = minPosition;
                }
                else
                {
                    throw new Exception("Unable to reach position");
                }
            }

            void UpdateNeighbours(IEnumerable<(int, int)> coordinates, int currentCost)
            {
                var neighbours = new List<MarkableNode>();
                foreach (var (cx, cy) in coordinates)
                {
                    neighbours.Add(Nodes[cx, cy]);
                }
                foreach (var neighbour in neighbours.Where(n => !n.Visited))
                {
                    var newCost = currentCost + neighbour.StepCost;
                    if (neighbour.ReachCost > newCost)
                    {
                        neighbour.ReachCost = newCost;
                    }
                }
            }
        }

        private bool TryGetMinimumCostPosition(out (int, int) position)
        {
            var minPosition = (-1, -1);
            var minReachCost = int.MaxValue;
            for (var i = 0; i < _map.SizeX; i++)
            {
                for (var j = 0; j < _map.SizeY; j++)
                {
                    var current = Nodes[i, j];
                    if (current.Visited)
                    {
                        continue;
                    }
                    if (current.ReachCost < minReachCost)
                    {
                        minReachCost = current.ReachCost;
                        minPosition = (i, j);
                    }
                }
            }
            position = minPosition;

            return minPosition != (-1, -1);
        }

        public int ReachPosition(int x, int y, int startX, int startY)
        {
            _position = (startX, startY);
            return ReachPosition(x, y);
        }
    }

}
