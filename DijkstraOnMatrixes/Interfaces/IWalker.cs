namespace DijkstraOnMatrixes.Interfaces
{
    public interface IWalker
    {
        int ReachPosition(int x, int y);
        int ReachPosition(int x, int y, int startX, int startY);
    }
}
