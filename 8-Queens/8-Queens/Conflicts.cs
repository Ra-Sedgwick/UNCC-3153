using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Conflicts
    {
        public Dictionary<int, List<int[]>> Table { get; set; }

        public Conflicts()
        {
            Table = new Dictionary<int, List<int[]>>();
        }

        public void Add(int queen, int[] coord)
        {
            if (!Table.ContainsKey(queen))
                Table.Add(queen, new List<int[]>());

            Table[queen].Add(coord);
        }
    }
}
