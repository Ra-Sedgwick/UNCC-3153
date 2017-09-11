using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Queen
    {
        public int X { get; set; }
        public int Y { get; set; }
        public HashSet<Queen> Conflicts { get; set; }

        public Queen(int _x, int _y)
        {
            X = _x;
            Y = _y;
            Conflicts = new HashSet<Queen>();
        }
    }

    public class QueenComparer : IComparer<Queen>
    {
        public int Compare(Queen x, Queen y)
        {
            if (x.Y < y.Y)
                return -1;
            else if (x.Y == x.Y)
                return 0;
            else
                return 1;
        }
    }
}
