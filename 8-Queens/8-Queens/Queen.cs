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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Conflicts.Any())
            {
                sb.Append("Queen:  ");
                sb.Append(X);
                sb.Append("-");
                sb.Append(Y);
                sb.Append(", Conflicts at:\n");

                foreach (var queen in Conflicts)
                {
                    sb.Append("\t");
                    sb.Append(queen.X);
                    sb.Append("-");
                    sb.Append(queen.Y);
                    sb.AppendLine();
                }
            }
           

            return sb.ToString();
        }
    }
}
