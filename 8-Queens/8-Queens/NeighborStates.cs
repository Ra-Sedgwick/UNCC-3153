using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (_x.Conflicts == _y.Conflicts)
                return 0;
            else
                return 1;
        }
    }
}
