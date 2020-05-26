using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes.Models
{
    public class MatrixMap : IMatrixMap
    {
        public int SizeX { get; }
        public int SizeY { get; }

        public MatrixMap(IMatrixMapArguments arguments, INodeFactory nodeFactory, INeighbourFuncFactory neighbourFuncFactory) : this(arguments.Path, arguments.Directions, nodeFactory, neighbourFuncFactory)
        {

        }

        public MatrixMap(string path, Directions directions, INodeFactory nodeFactory, INeighbourFuncFactory neighbourFuncFactory)
        {
            var lines = File.ReadAllLines(path);
            var N = lines.Count();

            Nodes = new Node[N, N];
            SizeX = N;
            SizeY = N;
            CreateNodes(nodeFactory, lines, N);

            GetNeighboursOf = neighbourFuncFactory.CreateFunc(directions, SizeX, SizeY);

            void CreateNodes(INodeFactory nodeFactory, string[] lines, int N)
            {
                for (var i = 0; i < N; i++)
                {
                    var costs = lines[i].Split(',');
                    for (var j = 0; j < N; j++)
                    {
                        var cost = Convert.ToInt32(costs[j]);
                        Nodes[i, j] = nodeFactory.CreateNode(cost);
                    }
                }
            }
        }

        public Node[,] Nodes { get; }

        public Func<int, int, IEnumerable<(int, int)>> GetNeighboursOf { get; set; }
    }
}
