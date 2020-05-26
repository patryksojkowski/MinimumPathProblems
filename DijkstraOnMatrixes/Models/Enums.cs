namespace DijkstraOnMatrixes.Models
{
    public enum Directions
    {
        None = 0,
        Down = 1,
        Up = 2,
        Right = 4,
        Left = 8,
        DownRight = Down | Right,
        All = Down | Up | Right | Left,
    }

    public enum ProblemEnum
    {
        Problem81,
        Problem82,
        Problem83
    }
}
