using DijkstraOnMatrixes.Interfaces;

namespace DijkstraOnMatrixes.Models
{
    public class MatrixMapArgumentsFactory
    {
        private static readonly string problem81Input = @"C:\Users\ezsojpa\source\repos\DijkstraOnMatrixes\p081_matrix.txt";
        private static readonly string problem82Input = @"C:\Users\ezsojpa\source\repos\DijkstraOnMatrixes\p082_matrix.txt";
        private static readonly string problem83Input = @"C:\Users\ezsojpa\source\repos\DijkstraOnMatrixes\p083_matrix.txt";

        public IMatrixMapArguments Create(ProblemEnum problem) =>
            problem switch
            {
                ProblemEnum.Problem81 => new MatrixMapArguments(problem81Input, Directions.DownRight),
                ProblemEnum.Problem82 => new MatrixMapArguments(problem82Input, Directions.DownRight),
                ProblemEnum.Problem83 => new MatrixMapArguments(problem83Input, Directions.All),
                _ => null,
            };
    }
}
