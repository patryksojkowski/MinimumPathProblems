using DijkstraOnMatrixes.Models;
using DijkstraOnMatrixes.Interfaces;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace DijkstraOnMatrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProblem83();
        }

        public static void RunProblem81()
        {
            using var container = new WindsorContainer();

            var argsFactory = new MatrixMapArgumentsFactory();
            var args = argsFactory.Create(ProblemEnum.Problem81);

            // Registration
            container.Register(Component.For<INeighbourFuncFactory>().ImplementedBy<MatrixNeighbourFuncFactory>());
            container.Register(Component.For<INodeFactory>().ImplementedBy<NodeFactory>());
            container.Register(Component.For<IMatrixMap>().ImplementedBy<MatrixMap>().DependsOn(args));
            container.Register(Component.For<IWalker>().ImplementedBy<MapWalker>());
            container.Register(Component.For<IProblem>().ImplementedBy<Problem81>());

            // Resolve Problem instance
            var problem = container.Resolve<IProblem>();

            // Run Problem Solving
            problem.Solve();
        }
        
        public static void RunProblem83()
        {
            using var container = new WindsorContainer();

            var argsFactory = new MatrixMapArgumentsFactory();
            var args = argsFactory.Create(ProblemEnum.Problem83);

            // Registration
            container.Register(Component.For<INeighbourFuncFactory>().ImplementedBy<MatrixNeighbourFuncFactory>());
            container.Register(Component.For<INodeFactory>().ImplementedBy<NodeFactory>());
            container.Register(Component.For<IMatrixMap>().ImplementedBy<MatrixMap>().DependsOn(args));
            container.Register(Component.For<IWalker>().ImplementedBy<MapWalker>());
            container.Register(Component.For<IProblem>().ImplementedBy<Problem83>());

            // Resolve Problem instance
            var problem = container.Resolve<IProblem>();

            // Run Problem Solving
            problem.Solve();
        }
    }
}