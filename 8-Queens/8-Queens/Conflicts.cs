using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Conflicts
    {
        public Dictionary<int[], List<int[]>> Table { get; set; }
        public int Count { get; set; }

        public Conflicts()
        {
            Table = new Dictionary<int[], List<int[]>>();
            Count = 0;
        }


        public void Add(int[] queen, int[] coord)
        {
            if (!Table.ContainsKey(queen))
                Table.Add(queen, new List<int[]>());

            Table[queen].Add(coord);
            Count++;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Conflicts: ");
            sb.Append(Count);

            
            foreach (var conflict in this.Table)
            {
                sb.Append("\nQueen at: ");
                sb.Append(String.Join("-", conflict.Key));
                sb.Append(", conflicting with queens at:\n");

                conflict.Value.ForEach(c => {
                    sb.Append("\t");
                    sb.Append(String.Join("-", c));
                    sb.Append("\n");
                });
            }

            return sb.ToString();
        }
    }
}
