using System.Collections.Generic;

namespace EightQueens
{
    public class NeighborStates
    {
        public SortedSet<Board> Table { get; set; }

        public NeighborStates()
        {
            Table = new SortedSet<Board>(new NeighborComparer());
        }
    }

    class NeighborComparer : IComparer<Board>
    {
        public int Compare(Board _x, Board _y)
        {
            if (_x.Conflicts < _y.Conflicts)
                return -1;
            else
                return 1;
        }
    }
}
